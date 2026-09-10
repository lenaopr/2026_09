from pathlib import Path

import matplotlib.pyplot as plt
import numpy as np


OUTPUT_PATH = Path(__file__).with_name("takeaway_average_deviation.png")

# Aggregated from TAO_1.sql's current timing rules for 2026-06-01 to 2026-09-01.
# Each metric excludes durations over 24 hours.
METRICS = {
	"Order accept time": {
		"counts": [75738, 42187, 15378, 15358, 3130, 1148, 202, 188, 184, 384],
		"average": 2.12,
		"average_under_30": 1.11,
		"p50": 0.52,
		"p90": 3.10,
		"tail_over_120": 384,
	},
	"Manual ready time": {
		"counts": [3200, 1298, 5110, 23550, 44747, 44351, 11419, 9149, 7737, 2738],
		"average": 18.97,
		"average_under_30": 9.87,
		"p50": 9.85,
		"p90": 39.99,
		"tail_over_120": 2738,
	},
}

BUCKETS = ["<=0.5", "0.5-1", "1-2", "2-5", "5-10", "10-20", "20-30", "30-60", "60-120", ">120"]


def plot_metric(axis: plt.Axes, title: str, values: dict[str, float | list[int]]) -> None:
	counts = np.array(values["counts"])
	total_orders = counts.sum()
	percentages = counts / total_orders * 100
	positions = np.arange(len(BUCKETS))

	colors = ["#2e86ab"] * 7 + ["#e67e22"] * 3
	axis.bar(positions, percentages, color=colors, width=0.78)
	axis.set_title(title, loc="left", fontweight="bold")
	axis.set_ylabel("Orders (%)")
	axis.set_xticks(positions, BUCKETS, rotation=35, ha="right")
	axis.set_ylim(0, max(percentages) * 1.22)
	axis.grid(axis="y", alpha=0.22)
	axis.set_axisbelow(True)

	summary = (
		f"Orders: {total_orders:,}\n"
		f"P50: {values['p50']:.2f} min\n"
		f"P90: {values['p90']:.2f} min\n"
		f"Average: {values['average']:.2f} min\n"
		f"Average <=30 min: {values['average_under_30']:.2f} min\n"
		f">120 min: {values['tail_over_120']:,} orders"
	)
	axis.text(
		0.98,
		0.96,
		summary,
		transform=axis.transAxes,
		ha="right",
		va="top",
		fontsize=9,
		bbox={"facecolor": "white", "edgecolor": "#9aa5ad", "boxstyle": "round,pad=0.45"},
	)


def main() -> None:
	figure, axes = plt.subplots(2, 1, figsize=(12, 10), constrained_layout=True)
	figure.suptitle(
		"Takeaway Timing: Distribution and Long-Tail Effect on Average\n"
		"2026-06-01 to 2026-09-01; durations >24 hours excluded",
		fontsize=14,
		fontweight="bold",
	)

	for axis, (title, values) in zip(axes, METRICS.items()):
		plot_metric(axis, title, values)

	figure.savefig(OUTPUT_PATH, dpi=180, bbox_inches="tight")
	print(f"Saved chart: {OUTPUT_PATH}")


if __name__ == "__main__":
	main()
