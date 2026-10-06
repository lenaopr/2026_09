from MyAirflowModule import *

schedule_interval='0 * * * *' ###hourly
default_args = {
    'owner': 'airflow',
    'depends_on_past': False,
    'start_date': airflow.utils.dates.days_ago(1),
    'catchup':False,
    'retries': 0,
    'retry_delay': timedelta(minutes=5),
    'on_failure_callback':task_fail_alert,
}

with DAG('TakeAway_Merchant_Offline_Alert_Report', 
         default_args=default_args, 
         schedule_interval=schedule_interval,
         max_active_runs=1,
         tags=[]) as dag:
    ######################################################################################
    bash_command='''cd /ReportingRoot/JupyterRoot/reports/TakeAway_Merchant_Offline_Alert_Report && \
    papermill /ReportingRoot/JupyterRoot/reports/TakeAway_Merchant_Offline_Alert_Report/TakeAway_Merchant_Offline_Alert_Report.ipynb \
    /ReportingRoot/JupyterRoot/reports/TakeAway_Merchant_Offline_Alert_Report/TakeAway_Merchant_Offline_Alert_Report_result.ipynb \
    --kernel report \
    --start_timeout 300
    '''
    t2 = BashOperator(
        task_id='GenReport',
        bash_command=bash_command, 
        dag=dag)
    ######################################################################################
    t2
