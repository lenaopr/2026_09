using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORLibrary.Common
{
    public enum WorkFlowType
    {
        ForGotPassWord = 0,
        ChangeEmail = 1,

        RmsForGotPassWord = 2,
        RmsChangeEmail = 3,
        RmsResetPassWord = 4,

        ChangePhone = 5,
        ConfirmChangePhone = 6,

        //set user status to "unverified" for Snap (first login as Snap user)
        LoginAsSnapUser = 7,
        
        BO_ForGotPassWord = 200,

        // For Mobile Registration 20170629
        SMSPhoneRegister = 20,  // Mobile Registration, account verified through SMS
        SMSForgotPassword = 21, // Forget password, account verified through SMS
        SMSChangePhone = 22,    // Change Phone number, account verified through SMS
        SMSPhoneRegisterComplete = 10020,   // The sms verification code input bby user is correct, so this code cannot be used again.
        SMSForgotPasswordComplete = 10021,  // The sms verification code input bby user is correct, so this code cannot be used again.
        SMSChangePhoneComplete = 10022,     // The sms verification code input bby user is correct, so this code cannot be used again.
        
        SMSAutoLoginOrRegister = 23, // For table booking auto register member 
        SMSAutoLoginOrRegisterComplete = 10023, // For table booking auto register member 

        SMSChangePhoneByMiniProgramHK = 24,             // (MiniProgram)Change Phone number, account verified through SMS 
        SMSChangePhoneByMiniProgramCN = 25,             // (MiniProgram)Change Phone number, account verified through SMS
        SMSChangePhoneByMiniProgramHKComplete = 10024,  // (MiniProgram)The sms verification code input by user; the code cannot be used again after verified.
        SMSChangePhoneByMiniProgramCNComplete = 10025,  // (MiniProgram)The sms verification code input by user; the code cannot be used again after verified.
    };

    //public enum PoiRegion
    //{
    //    Unspecified = -1,
    //    HongKong = 0,
    //    Macau = 1,
    //    ShenZhen = 2
    //}

    public enum ArticleStatus
    {
        Inactive = 0,
        Draft = 1,
        Active = 10
    }

    public enum RecipeStatus
    {
        Inactive = 0,
        Draft = 1,
        Pending = 2,
        Reject = 3,
        Others = 5,
        Active = 10
    }

    public enum HtmlBlockGroupMode
    {
        Random = 1,
        Cycle = 2
    }

    public enum PoiRankingType
    {
        SmileMinusCry = 0, // for the overall charts
        ORScore = 0,
        CryMinusSmile = 1,
        ScoreOverall = 2,
        //Buffet = 3,
        SmileForAll = 4, // ranked across all pois, for other charts
        SmileMinusCryForAll = 5,
        //CryForAll = 6,
        ReviewCountForAll = 7,
        //ScoreOverallForAll = 8,
        ORScore2 = 10,
        CryMinusSmile2 = 11,
        ScoreOverall2 = 12,
        //#if ORV4
        PageView = 13,
        BookingMark = 14,
        Dessert = 15,   // v5 new chart
        //#endif
    };

    public enum RecipeRankingType
    {
        ORScore = 1,    // for lang1
        ORScore2 = 2    // for lang2
    };

    public enum UserRankingType
    {
        ORScore = 1,
        ORScore2 = 2,
        GourmetChallengeGroupA = 3,
        GourmetChallengeGroupB = 4,
        GourmetChallengeGroupC = 5,
    };

    public enum DurationType
    {
        Last30Days = 0,
        PreviousMonth = 1,
        LastHalfYear = 2,
        LastYear = 3,
        AllTime = 4,
        Last3Months = 5,
        Last365Days = 6,
        Last1095Days = 7,
        Last90Days = 8,

        GourmetChallengePhase1 = 10,
        GourmetChallengePhase2 = 11,
        GourmetChallengePhase3 = 12,
        GourmetChallengePhase4 = 13,
        GourmetChallengePhaseAll = 14
    };

    public enum SortType
    {
        ScoreSmileDesc = 2,
        ScoreSmileAsc = 9,

        ScoreCryDesc = 10,
        ScoreCryAsc = 3,

        ReviewCountDesc = 20,
        ReviewCountAsc = 7,

        ConsumeDesc = 11,
        ConsumeAsc = 4,

        ScoreAllDesc = 1,
        ScoreAllAsc = 8,

        // 21 - 30 will be reserved for HK
        //ScoreEnvDesc    =21,
        //ScoreEnvAsc    =22,
        //ScorePriceDesc  =23,
        //ScorePriceAsc  =24,
        //ScoreTasteDesc=25,
        //ScoreTasteAsc=26,
        //ScoreCleanDesc=27,
        //ScoreCleanAsc=28,
        //ScoreServiceDesc=29,
        //ScoreServiceAsc = 30,

        //hidden
        ScoreSmileMinusCryDesc = 100,
        ScoreSmileMinusCryAsc = 101,

        ORScoreDesc = 31,
        ORScoreAsc = 32,
        NameLang2Desc = 41,
        NameLang2Asc = 42,
        NameLang1Desc = 43,
        NameLang1Asc = 44,

        CoupnPublishTime = 51,
        CouponExpireTimeDes = 52,
        CouponExpireTimeAsc = 53,
        CouponRestaurantNameAsc = 54,
        CouponRestaurantNameDes = 55,

        Default = 0
    };

    public enum PhotoOrderType
    {
        Total = 0,
        ofRestaurant,
        ofPersonal
    };

    public enum PhotoPriority
    {
        CorpUserPhotoOnly = 5,
        Staff = 10,
        MemberReview = 20,
        MemberPhotoOnly = 30,
        GuestReview = 40,
        GuestPhotoOnly = 50,
        MemberPersonal = 100,
    }

    public enum UserHasPhoto
    {
        None = 0,
        Icon = 1,
        Upload = 2,
        FBUpload = 3,
        QQUpload = 4,
        SinaUpload = 5,
        YahooUpload = 6,
        GooglePlusUpload = 7
    }

    public enum UserPhotoType
    {
        //用户自己的头像
        UserAvatar = 0,
        //用户上传用来评论餐厅的图片
        Review = 1,
        Windows = 2,
        //用户上传后没有审核的图片
        PhotoPending = 3,
        Recipe = 4,
        Article = 5,
        Coupon = 6,
        //DBS = 7,
        Badge = 8,
        FeatureItem = 9,
        Listing = 10,
        FoodNews = 11,
        Chain = 12,
        CorpAccount = 13,
        MData = 14,
        CMSContent = 15,
        CMSSubContent = 16,
        File = 17, //major for menu at this moment
        Notice = 18,
        RMSPoiPhoto = 19, //extra 2 photos in sr2.
        CorpJobPhoto = 20, //for corp job logo
        GroupBuyOfferPhoto = 21,
        GroupBuyProviderPhoto = 22,
        BriefPhoto = 23,
        BriefPhotoPending = 24,
        PoiMap = 25,
        CouponQR = 26,
        PoiPending = 27,   // Only Door photo revision: 83178
        CouponPassCodeQR = 35,
        PhotoPendingTesting = 36,
        ReviewTesting = 37,
        UserThemeBg = 38,
        TopicImg = 39,
        TopicItemImg = 40,
        TempPhoto = 41,
        PoiRankingPhoto = 42,
        SearchGuidePhoto = 43,
        CodeTablePhoto=44,
        Author = 45,
        InboxNotification = 46,
        PoiDocument = 47,
    };
    public enum Enum_PoiPending
    {
        DoorPhoto = 27
    }

    public enum upLoadPhotoType
    {
        //用户上传相片的类型
        Food = 1,
        Inside = 2,
        Outside = 3,
        Others = 4,
        Bill = 6,
        Menu = 7
        // ApprovePoiDoorPhoto = 27
    }

    public enum PhotoSource
    {
        user = 1,
        admin = 2,
        restaurant = 3
    }

    public enum MediaSource
    {
        user = 1,
        admin = 2,
        restaurant = 3
    }

    //public enum PhotoType
    //{ 
    //   Restaurant=1,
    //   user,
    //   Review
    //}

    //public enum PhotoResizeWidth
    //{
    //    Lager = 480,  // l
    //    Middle = 413,  // m
    //    Nallow = 285,  // n
    //    Dellow = 150,  // d
    //    Crop = 150,  // c
    //    Small = 81,  // s
    //    C95 = 95,  // p
    //    C80 = 80,  // q
    //    C45 = 45,  // r
    //    C32 = 32,  // t
    //    origiral = 0, // o
    //    tojpg = 0 // j -- no resize,just convert to jpg
    //}

    public enum BOReviewType    //only use for BO
    {
        Member = 1,
        Non_member,
        On_hold,
        Reconfirm,
        Delisted,
        Trivial,
        WhiteListed,
    }

    public enum ReviewType
    {
        Member = 1,
        Non_member,
        On_hold
    }

    public enum DisplayType
    {
        Reviews = 1,
        Photos_only
    }
    public enum ReviewStatus
    {
        Draft = 0, // for reviewpending only (save as draft)
        Deactivate = 0,  // for review only
        Pending = 1, // for reviewpending only
        Rejected, // for reviewpending only
        Onhold, // for reviewpending only
        Deleted, // for reviewpending only (delete by user)
        RejectDirect, // for reviewpending only, user cannot resubmit so easily like rejected reviews. 
        DeleteByAdmin = 8, // for reviewpending only, BO staff found review duplicate so keep only the latest one and delete
        Activate = 10, // for review only
        Approve = Activate,
    }

    public enum BriefReviewStatus
    {
        Deactivate = 0,
        Hide = 1,
        Activate = 10
    }
    //public enum CountryType     
    //{ 
    //    HongKong = 1,            
    //    Malaysia,            
    //    Singapore,           
    //    Thailand ,           
    //    China ,              
    //    India ,              
    //    Indonesia ,          
    //    Philippines ,        
    //    Taiwan              
    //}
    public enum PlatformType
    {
        iphone = 1,
        android,
        BB,
        windowphone
    }

    public enum ReviewPendingStatus
    {
        Draft = 0, // for reviewpending only (save as draft)
        Deactivate = 0,  // for review only
        Pending = 1, // for reviewpending only
        Rejected = 2, // for reviewpending only
        Onhold, // for reviewpending only
        Deleted, // for reviewpending only (delete by user)
        RejectDirect, // for reviewpending only, user cannot resubmit so easily like rejected reviews. 
        UploadingPending = 6, // for API uploading review, for reviewpending only
        UploadingDraft = 7,  // for API uploading draft review, for reviewpending only
        DeleteByAdmin = 8, // for reviewpending only, BO staff found review duplicate so keep only the latest one and delete
        Activate = 10, // for review only
        Approve = Activate,
    }
    // Do not delete this, ideally should be like this, but one of the BO's search filters ('Review Status') need to deal with this first.
    //public enum ReviewStatus
    //{
    //    Deactivate = 0,  // for review only
    //    Activate = 10, // for review only
    //    Approve = Activate
    //}
    //public enum ReviewPendingStatus
    //{
    //    Draft = 0, // for reviewpending only (save as draft)
    //    Pending = 1, // for reviewpending only
    //    Rejected, // for reviewpending only
    //    Onhold, // for reviewpending only
    //    Deleted, // for reviewpending only (delete by user)
    //}

    public enum ReviewTableType
    {
        Review = 1,
        ReviewPending,
        Comment,
        PhotoPending,
        Photo,
        MediaPending,
        Media,
        AllPhoto


    }

    //public enum PhotoResizeType
    //{
    //    Lager = 0,
    //    Middle,
    //    Nallow,
    //    Dellow,
    //    Crop,
    //    Small
    //}

    public enum ApproveActionType
    {
        UpdateReviewPending = 1,
        Approve,
        MoveRestaurant,
        Onhold,
        Reject,
        NonReview
    }

    public enum UserTableType
    {
        User = 1,
        UserPending,
        Bbs
    }

    //Photo Status
    public enum Enum_PhotoStatus
    {
        Active = 10, // Because Review is active
        Inactive = 0 // Because Review is inactive
    }

    // PhotoStatus, PhotoPendingStatus, CouponPhoto.Status
    public enum PhotoApproveType
    {
        pending = 0,
        Preview = 1,
        Approve = 2,
        Reject = 3,
        Delete = 4,
        ApprovedAsFile = 5
    }

    public enum Enum_PhotoPendingProcessQueueStatus
    {
        Inactive = 0,
        Active = 10,
        Done = 20,
    }

    public enum MemeberPhotoActionType
    {
        Approve = 1,
        Reject = 2,
    }

    public enum CouponPhotoType
    {

        Logo = 1,
        DoorPhoto,
        CouponQR
    }

    public enum CouponStatus
    {
        Hide = 0,
        Pending = 2, // for RMS
        Normal = 10,
        Draft = 5,
        QuotaFilled = 6,
        Premium = 20
    }

    public enum CouponBOStatus
    {
        Hide = 0,
        Expired = 1,
        Pending = 2,
        Future = 3,
        Draft = 5,
        Normal = 10,
        Premium = 20
    }

    // 20161223 OR-38106
    // May add  PartnerApp = 50 or (PartnerAlipay=51, PartnerAsiamiles=52) in future if needed
    public enum Enum_UserTypeId
    {
        Normal = 0,
        VIP = 100,
        Tester = 200
    }

    public enum UserStatus
    {
        deactivate = 0,
        no_email = 4, // for system-generated users created through AlipayApp
        suspended = 5,
        unverified = 7,//email is not verified
        active = 10,
        active_nonvalidate = 11
    }


    // private. just to avoid showing in backoffice while looping UserStatus.
    public enum DeveloperUserStatus
    {
        Admin = 20
    }

    public enum CorpUserStatus
    {
        Inactive = 0,
        NotVerified = 5,
        Active = 10,
        //Staff = Active,
        Admin = 20  // For OpenRice Staff
    }

    public enum ReviewCommentUserId
    {
        CorpUser = -2
    }

    public enum LogRestSearchType
    {
        code = 0,
        cname = 1,
        caddr = 2,
        csign = 3,
        random = 4,
        mobileCode = 5,
        mobileCname = 6,
        mobileCsign = 7,
        mobilerandom = 8,
        cnamese = 9,
        phone = 10,
        mobileCaddr = 11,
        empty = 12,
        cnamess = 13,
        cpopulartag = 14,
        ctag = 15
    }

    public enum RestaurantMapGetType
    {
        None = 0,
        HandMark, // hand marked from BO
        Get, // get from google via BO using an address
        Landmark, // batch update via a landmark address match (via sql)
        Batch = 100, // via re-get script - starting from 100, 101, 102..
    }

    public enum StatPoiSearchEvaluatorType
    {
        weekly = 0,
        monthly
    }

    public enum MEventStatus
    {
        Disable = 0,
        Enable = 10
    }

    public enum JsGetBlockType : int
    {
        Undefined = 0,
        JSRestType1 = 1,
        JSGourmetType1,
        JSGourmetType2,
        JSGourmetType3,
        JSGourmetType4,
        ImgGourmetType1,
        ImgGourmetType2,
        ImgGourmetType3,
        ImgGourmetType4,
        FlashGame1 = 10,
        IndexFeaturedRest = 11,
        ChannelFeaturedRest = 12,
        IndexFeaturedCoupon = 13,
        ChannelFeaturedCoupon = 14,
        MobileIndexBanner = 15,

    }

    public enum TrackType
    {
        Impression = 1,
        Click = 2
    }

    public enum EmailSuppressType
    {
        Hotmail = 1,
        SNAP = 2
    }

    public enum EmailSuppressSubscription
    {
        enews = 1,
        promotions = 2,
        groupbuy = 3
    }

    public enum Enum_SnapEmailSuppressSubscription
    {
        ENews = 1,
    }

    public enum FeatureType
    {
        Restaurant = 1,
        RestaurantCoupon = 2,
        RestaurantGroup = 3,
        CMSContent = 4,
        DirectMarketing = 5,
        HotRestaurant = 6,
        NewRestaurant = 7,
        Chain = 8,
        Article = 9,
        Job = 20,
        AppIndexSlideRestaurant = 28,
        AppIndexSlideChain = 30,
        AppIndexSlideCoupon = 32,
        AppIndexSlideCMSContent = 34,
        AppIndexSlideUrl = 36
    }

    public enum ChannelType
    {
        Main = 1,
        SpecialLandingpage = 2,
        SpecialListing = 3

    }

    //ActionLog
    public enum ActionType : int
    {
        ChangePhoneSMS_Deactive = 206,
        SMSSendConfirmCode = 106,
        //Mobile Action 9000-9999
        Mobile_Action_Min = 9000,
        Open_QR_Code_Scanner = 9100,//    QR_OpenScanner = 81
        Scanned_QR_Code = 9200,//QR_ScanUrl = 82
        Submit_xmas_wap_form = 9300,//ChristmasWapForm = 101
        Scanned_AppStore_Lang1_QR_iDevice = 9400,
        Scanned_AppStore_QR_iDevice = 9450,
        Scanned_AppStore_Lang1_QR_android = 9500,
        Scanned_AppStore_QR_android = 9550,
        Scanned_AppStore_Lang1_QR_wp = 9600,
        Scanned_AppStore_QR_wp = 9650,
        Mobile_Action_Max = 9999,

        //Visitor Action 10000-11999
        Visitor_Action_Min = 10000,
        Cannot_register_with_blackout_IP = 10100,// RegistrationAutoBlackOutUser = 70
        Sending_contactus_enquiry_to_restaurant = 10200,//RestaurantOpinion = 29,
        Visitor_Action_Max = 11999,

        //Award Action 12000-12999
        Award_Action_Min = 12000,
        Visitor_registered = 12100,//Awardemailconfirm = 46
        Visitor_registering = 12200,//Awardregister = 45
        Voting_on_Wap = 12300,//AwardVote = 47,
        Voting_on_Web = 12400,//MobileAwardVote = 48,
        Voting_on_IOS = 12410,
        Voting_on_Android = 12420,
        Vote_via_QR_code = 12500,//QRAwardVote = 80,
        Vote_via_QR_code_Wap = 12510,
        Vote_via_QR_code_IOS = 12520,
        Vote_via_QR_code_Android = 12530,
        Award_Action_Max = 12999,

        //Restaurant Owner Action 13000-13999
        Restaurant_Owner_Action_Min = 13000,
        Advertising_enquiry = 13100,//RestaurantAdhere = 31
        Owner_report_information = 13200,//RestaurantFormPage2 = 37
        Owner_submit_coupon = 13300,//RestaurantFormAddCoupon = 40
        Restaurant_Owner_Action_Max = 13999,

        //Social Action 14000-14999
        Social_Action_Min = 14000,
        Auto_FB_connect = 14100,//FacebookAutoLogin = 61
        Cancelled_Publish_permission = 14150,//FacebookUserRemovePublishPermission = 58
        Connected_FB_account_to_OR_account = 14200,//FacebookMapAccount = 62
        Connected_Google_account_to_OR_account =14210,
        Connected_Apple_account_to_OR_account = 14220,
        Download_QQ_Avatar = 14250,//QQDownloadAvatar = 83
        Download_GPlus_Avatar = 14275,
        Download_Sina_Avatar = 14300,//SinaDownloadAvatar = 86
        Download_Yahoo_Avatar = 14325,
        Download_Avatar = 14350,//FacebookDownloadAvatar = 63
        Edit_activity_feed_setting = 14400,//ActivityFeedSetting = 15001
        Granted_Publish_Permission = 14450,//FacebookUserGrantPublishPermission = 59
        Login_QQ = 14500,//QQLogin = 84
        Login_GPlus = 14525,
        Login_Sina = 14550,//SinaLogin = 87
        Login_Yahoo = 14575,
        Manual_FB_connect = 14600,//FacebookLogin = 60
        Manual_GPlus_connect = 14601,
        Manual_QQ_connect = 14602,
        Manual_Sina_connect = 14603,
        Manual_IM_connect = 14610,
        Map_QQ_Account = 14650,//QQMapAccount = 85
        Map_Sina_Account = 14700,// SinaMapAccount = 88
        Map_GPlus_Account = 14725,
        Share_photo_via_facebook = 14750,// SharePhoto_facebook = 93
        Share_photo_via_msn = 14800,// SharePhoto_msn = 91
        Share_photo_via_twitter = 14850,//SharePhoto_twitter = 92
        Share_sr2_via_iphone_copy = 14860,
        Share_sr2_via_iphone_sms = 14870,
        Share_sr2_via_iphone_email = 14880,
        Share_sr2_via_iphone_facebook = 14890,
        Social_Action_Max = 14999,


        //Member Personal Action 15000-15999
        Member_Personal_Action_Min = 15000,
        Change_email_Alert_setting = 15050,//MyOpenRiceMessageEmailAlert = 42
        Change_Password = 15100,//MyOpenRiceChange_PassWord = 27
        Confirm_forgeted_password = 15150,//WorkFlowforgetpassword_update = 17
        Confrim_change_email = 15200,//WorkFlowchangeemail_confirm = 20
        Delete_BBS_message = 15250,//MyOpenRiceDeleteBbs = 36
        Delete_personal_photo = 15300,//MyOpenRiceDelwindowphoto = 22
        Detete_MyOR_photo = 15350,//MyOpenRiceDelphoto = 21
        Edit_extra_profile_info = 15400,//MyOpenRiceEditPublicInfo = 28
        Edit_MyOR_photo_caption = 15450,//MyOpenRiceEditPhotoCaption = 23
        Edit_personal_info = 15500,// MyOpenRiceEditPersonalInfo = 25
        FE_WorkFlowchangephone_confirm = 15510,//WorkFlowchangephone_confirm
        Edit_review_draft = 15520,// RestaurantDraftReviewUpdate = 34
        Edit_review_draft_for_pending_poi = 15521,
        Email_change_request = 15540,//WorkFlowChangeEmail = 19
        Forget_password_request = 15560,//WorkFlowforgetpassword = 18 //ORV5 still using this
        SMS_Forget_Password = 15561,            // For Mobile Registration 20170629  
        SMS_Change_Phone = 15563,               // For Mobile Registration 20170629
        SMS_Change_Phone_Complete = 15564,      // For Mobile Registration 20170629
        SMS_Change_PhoneByMiniProgram_HK = 15565,               // For Miniprogram Registration 20191204
        SMS_Change_PhoneByMiniProgram_HK_Complete = 15566,      // For Miniprogram Registration 20191204
        SMS_Change_PhoneByMiniProgram_CN = 15567,               // For Miniprogram Registration 20200102
        SMS_Change_PhoneByMiniProgram_CN_Complete = 15568,      // For Miniprogram Registration 20200102
        Get_widget = 15580,//RestaurantGetWidget = 35
        Login_after_reconfirm_email = 15600,//MemberLoginReactive = 2
        Login_on_Wap = 15620,//MobileUserLogin = 5
        Login_on_Web = 15640,//MemberLoginLogin = 4
        Login_on_API = 15650,
        Registed = 15680,//Registrationregister_gourmet_verify_email = 9
        Registering = 15700,//RegistrationRegister = 11
        Reply_BBS = 15720,//MyOpenRiceReplyBbs = 24
        Save_review_draft = 15740,//RestaurantDraftReview = 33
        Save_review_draft_for_pending_poi = 15741,
        Subscribe_eNews = 15760,//Subscribe = 43
        Unsubscribe_eNews = 15780,//Unsubscribe = 44
        UnSubscribe_eNews_by_email_link = 15800,//EmailUnsubscribe = 52
        Upload_MyOR_personal_photo = 15820,//MyOpenRicePersonalPhoto = 39
        Upload_MyOR_restaurant_photo = 15840,//MyOpenRiceRestaurantPhoto = 38
        Verified_and_submitted_extra_profile_info = 15860,//RegistrationEmailVerified = 10
        Verified_confirm_email = 15880,//MemberLoginConfirmemail = 3

        Via_FB_registering = 15900,//Registrationregister_gourmet_via_facebook = 64
        Via_GPlus_registering = 15912,
        Via_QQ_registering = 15913,
        Via_Weibo_registering = 15914,

        Coupon_print = 15920,

        Via_FB_registering_IPhone = 15940,
        Via_GPlus_registering_IPhone = 15942,
        Via_QQ_registering_IPhone = 15943,
        Via_Weibo_registering_IPhone = 15944,

        Via_FB_registering_Android = 15950,
        Via_GPlus_registering_Android = 15952,
        Via_QQ_registering_Android = 15953,
        Via_Weibo_registering_Android = 15954,

        Bookmark_Restaurant_Add_Web = 15960,
        Bookmark_Restaurant_Add_MobileWeb = 15961,
        Bookmark_Restaurant_Add_iPhone = 15962,
        Bookmark_Restaurant_Add_Android = 15963,

        Bookmark_Restaurant_Delete_Web = 15964,
        Bookmark_Restaurant_Delete_MobileWeb = 15965,
        Bookmark_Restaurant_Delete_iPhone = 15966,
        Bookmark_Restaurant_Delete_Android = 15967,

        Member_Personal_Action_Max = 15999,

        //Member Public Action 16000-16999
        Member_Public_Action_Min = 16000,
        Comment_article = 16050,//ArticleComment = 0
        Comment_on_member_BBS = 16100,//GourmetBbs = 1
        Comment_photo = 16150,// PhotoComment = 74
        Comment_recipes = 16200,//RecipesComment = 6
        Comment_review = 16250,//RestaurantComment = 16
        Edit_review = 16300,//UserEditReview = 71
        Edit_review_BloggerTool_Enable = 16305,
        Edit_review_BloggerTool_Disable = 16306,
        Edit_review_BloggerTool_Confirm = 16310,
        Email_sharing_CMS = 16350,//CMSEmailFriend = 100
        Email_sharing_restaurant = 16400,//RestaurantEmailFriend = 13
        Recommend_review = 16450,//ReviewRating = 32
        Recommend_photo = 16460,
        Recommend_photo_quick = 16461,
        Reply_photo_comment = 16500,//PhotoCommentReply = 75
        Reply_review_comment = 16550,//RestaurantCommentReply = 54
        Report_map = 16600,//RestaurantMapReport = 30
        Report_restaurant_info = 16650,//RestaurantReport = 15
        Report_review = 16700,//RestaurantFlagReview = 12
        Submit_recipe = 16750,//RecipesSubmitok = 8
        Submit_review_serious_complaint_approve = 16770,
        Submit_review_auto_approve = 16780,
        Submit_review = 16800,//RestaurantSubmitReview = 14
        Submit_review_for_pending_poi = 16801,
        Submit_review_photo = 16810,

        // for ORV4
        Submit_review_recomfoodphoto = 16811,
        // endif

        Submit_review_photo_error = 16812,
        submiting_recipe = 16820,//RecipesSubmitrecipe = 7
        Submit_short_review = 16840,//RestaurantSubmitBriefReview = 73
        Upload_delivery_menu = 16860,//UploadFoodDeliveryMenu = 72
        Upload_nonreview_photo = 16880,//RestaurantUploadPhotoOnly = 41
        Vote_emoticon = 16900,//WebServiceVoteEmotion = 51

        Submit_review_auto_approve_API = 16910, // no longer in use after ORV5
        Submit_review_API = 16920,//RestaurantSubmitReview = 14
        Submit_review_photo_API = 16930,
        Submit_photo_API = 16940,

        Member_Public_Action_Max = 16999,

        //E-Commerce  17000-17999
        E_Commerce_Min = 17000,
        Product_Bought = 17100,//ProductOrderResultSuccess = 66
        Purchase_fail = 17500,//ProductOrderResultFail = 67
        Purchasing_product = 17800,//ProductOrderCreate = 65
        E_Commerce_Max = 17999,

        //Admin 18000-18999
        Admin_Min = 18000,
        Subscribe_eNew_to_member = 18100,//AdminSubscribe = 49
        UnSubscribe_eNew_to_member = 18300,//AdminUnsubscribe = 50
        Update_avatar_to_member = 18500,//MyOpenRiceMyopenrice_admin_avatar = 26
        UpdateActivePoiTMPoiId = 18600, // no longer in use after 20170321 as no one will trace this
        Admin_Max = 18999,

        //Group Buy 19000-19999
        Group_Buy_Min = 19000,
        Email_groupbuy_offer = 19300,//GroupBuy_EmailFriend = 1301
        Paydollar_Gateway_cancel = 19400,//GroupBuy_PayDollarGatewayCancel = 1313
        Paydollar_Gateway_confirm = 19500,//GroupBuy_PayDollarGatewaySuccess = 1311
        Paydollar_Gateway_Fail = 19600,//GroupBuy_PayDollarGatewayFail = 1312
        Paydollar_payment_Fail = 19700,//GroupBuy_PayDollarDataFeedFail = 1315
        Paydollar_payment_success = 19720,//GroupBuy_PayDollarDataFeedSuccess = 1314
        SMS_for_Groupbuy_fail = 19750,//GroupBuy_SmsConfirmFail = 1332, ,//13032
        SMS_for_Groupbuy_success = 19800,//GroupBuy_SmsConfirmSuccess = 1331
        Subscribe_GroupBuy_eNew = 19820,//GroupBuy_Subscribe = 1341
        Verify_GroupBuy_Email = 19840,//GroupBuy_EmailConfirmSuccess = 1321
        Verify_GroupBuy_Email_fail = 19860,//GroupBuy_EmailConfirmFail = 1322, ,//13022
        //GroupBuy_PayDollarDataFeedFailEmail = 19880,
        Print_GroupBuy_Coupon_via_MyOpenrice = 19900,
        Group_Buy_Max = 19999,


        //RMS 20000-21999
        RMS_Min = 20000,
        RMS_add_category = 20050,//RMS_AddFileCategory = 1221
        RMS_add_or_remove_branch = 20100,//RMS_AddOrRemoveBranchRestaurant = 1210
        RMS_corp_account_edit_job = 20150,//RMS_CorpJobEdit = 1229
        RMS_corp_account_saved = 20200,//RMS_CorpAccountsaveFromCorpJob = 1230
        RMS_corp_account_user_create = 20250,//RMS_NewCorpUser = 1201
        RMS_corp_account_user_delete = 20270,//RMS_DeleteCorpUser = 1203
        RMS_corp_account_user_edit = 20300,//RMS_EditCorpUser = 1202
        RMS_corp_account_user_verifing = 20320,//RMS_CorpUserVerifyEmail = 1204
        RMS_deactivate_job = 20340,//RMS_CorpJobDeactive = 1232
        RMS_delete_job = 20360,//RMS_CorpJobDelete = 1234
        RMS_file_caption_edit = 20380,//RMS_EditFileCaption = 1220
        RMS_file_category_delete = 20400,//RMS_DeleteFileCategory = 1222
        RMS_file_chain_poi_delete = 20410,//
        RMS_file_delete = 20420,//RMS_DeleteFile = 1219
        RMS_file_upload = 20440,//RMS_UploadFile = 1218
        RMS_foodnew_photo_caption_edit = 20460,//RMS_EditFoodNewsPhotoCaption = 1224
        RMS_foodnew_photo_delete = 20500,//RMS_DeleteFoodNewsPhoto = 1226
        RMS_foodnew_photo_upload = 20520,//RMS_UploadFoodNewsPhoto = 1225
        RMS_forget_password_request = 20540,//RMS_WorkFlowforgetpassword = 1206
        RMS_corpuser_change_password = 20545,
        RMS_login = 20560,//RMS_CorpUserLogin = 1205
        RMS_package_credit_usage = 20580,//RMS_CorpPackageCreditUsed = 1236
        RMS_photo_caption_edit = 20600,//RMS_EditPhotoCaption = 1215
        RMS_photo_delete = 20620,//RMS_DeletePhoto = 1216
        RMS_photo_reorder = 20640,//RMS_FileReorder = 1223
        RMS_photo_upload = 20660,//RMS_UploadPhoto = 1217
        RMS_post_job = 20680,//RMS_CorpJobPostConfirm = 1235
        RMS_reactive_job = 20700,// RMS_CorpJobReactive = 1233
        RMS_reply_review_comment = 20720,//  RMS_RestaurantCommentReply = 1214
        RMS_repost_job = 20740,//RMS_CorpJobRepost = 1231
        RMS_reset_password_request = 20760,//RMS_ResetPassword = 1208
        RMS_restaurant_edit = 20780,//RMS_EditRestaurant = 1212
        RMS_review_comment = 20800,//RMS_RestaurantComment = 1213

        RMS_chain_edit = 20810,
        RMS_chain_deletelogo = 20811,
        RMS_chain_deletebgphoto = 20812,
        RMS_chain_updatebgphoto = 20814,
        RMS_chain_updatelogo = 20815,
        RMS_chain_updatecoverphoto = 20816,

        RMS_corp_edit = 20850,
        RMS_corp_deletebgphoto = 20852,
        RMS_corp_deletecoverphoto = 20854,
        RMS_corp_deletecoverphoto2 = 20855,
        RMS_corp_updatebgphoto = 20856,
        RMS_corp_updatecoverphoto = 20858,
        RMS_corp_updatecoverphoto2 = 20859,

        RMS_landmark_edit = 20870,
        RMS_landmark_deletebgphoto = 20872,
        RMS_landmark_deletecoverphoto = 20874,
        RMS_landmark_deletecoverphoto2 = 20875,
        RMS_landmark_deletelogo = 20876,
        RMS_landmark_updatecoverphoto = 20878,
        RMS_landmark_updatecoverphoto2 = 20879,
        RMS_landmark_updatelogo = 20880,
        RMS_landmark_updatebgphoto = 20882,


        RMS_save_job_draft = 20820,//RMS_CorpJobSaveDraft = 1237
        RMS_sent_forget_password_request = 20840,//RMS_WorkFlowforgetpassword_update = 1207
        RMS_submit_coupon = 20860,//RMS_AddCoupon = 1211
        RMS_submit_job = 20900,//RMS_CorpJobAdd = 1228
        RMS_upload_logo = 20950,//RMS_CorpAccountUploadLogo = 1227,//
        RMS_delete_logo = 20952,//RMS_CorpAccountUploadLogo = 1227,//
        RMS_Max = 21999,

        NameCard = 22000
    }

    public enum BBSStatus
    {
        deactivated = 0,
        normal = 10
    }

    public enum LandmarkStatus
    {
        Inactive = 0,
        Active = 10,
        ShortListed = 15,
    }

    public enum Enum_LandmarkIsAutoMapping
    {
        No = 0,
        Yes = 1
    }

    public enum Enum_SeoRuleStatus
    {
        Inactive = 0,
        Active = 10
    }

    public enum Enum_LandmarkType
    {
        Landmark = 1,
        Mall = 2,
        Station = 3, //Train
        District = 4, // special district (non-offical, but popular)
        Hotel = 5,
        Food = 6
    }
    /// <summary>
    /// Don't overlap with Enum_LandmarkType, just for easier reference.
    /// </summary>
    public enum LandmarkGroupType
    {
        Landmark = 1,
        Mall = 2,
        Station = 3, //Train
        Hotel = 5,
        Food = 6
    }

    public enum LandmarkGroupStatus
    {
        Inactive = 0,
        Active = 10
    }

    public enum ListingStatus
    {
        Hide = 0,
        Closed = 1,
        Others = 2,
        Normal = 10,
        Premium = 20,
        TopPremium = 30,
        Renovate = 3
    }

    public enum ListingBOStatus
    {
        Hide = 0,
        Closed = 1,
        Others = 2,
        Renovate = 3,
        Expired = 4,
        Future = 5,
        Normal = 10,
        Premium = 20,
        TopPremium = 30
    }

    public enum SubListingStatus
    {
        Deactivated = 0,
        Normal = 10,
        Special = 20
    }

    public enum ListingPhotoType
    {
        DoorPhoto = 1,
        Logo,
        Restaurant,
        Menu
    }

    public enum Enum_PoiDocumentStatus
    {
        Deleted = 0,
        Inactive = 1,
        Active = 10,        // check StartDate and EndDate to show [Expired] instead...
    }
    public enum Enum_PoiDocumentMasterStatus
    {
        Expired = 1,
        Rejected = 2,
        Pending = 5,
        Verified = 10
    }
    public enum Enum_PoiDocumentMasterBankStatus
    {
        Rejected = 2,
        Pending = 5,
        Verified = 10
    }
    public enum Enum_PoiDocumentMasterSource 
    {
        Unknown  = 0,
        SecureBO = 1,
        EForm    = 2,
    }

    public enum Enum_PoiDocumentTypeStatus
    {
        Inactive = 0,
        Active = 10,
    }

    public enum Enum_PoiDocumentMasterBusinessEntityType
    {
        Individual = 1,
        Enterprise = 2,
    }

    public enum Enum_PoiServiceVerifyStatus
    {
        Inactive = 0,
        Active = 10
    }

    //use the value to sort searchsuggest order
    public enum SearchSuggestType
    {
        Cuisine = 1000,
        Dish = 2000,
        Amenity = 3000,
        Theme = 4000,
        SignDish = 5000,
        DistrictGroup = 6000,
        District = 7000,
        Landmark = 8000,
        Region = 9000
    }

    public enum FoodNewsStatus
    {
        Deactivated = 0,
        Pending = 2,
        Normal = 10,
        Premium = 20
    }

    // move to ORFramework
    public enum SysPrefStatus
    {
        Inactive = 0,
        Active = 10
    }

    public enum AppLanguage
    {
        ALL = 0,
        HK = 1,
        EN = 2,
        CN = 3,
        TW = 4,
        JP = 5
    }

    //public enum Language 
    //{ 
    //    hk,
    //    en,
    //    cn
    //}

    public enum AwardCategoryStatus
    {
        Inactive = 0,
        Active = 10
    }

    public enum AwardEntryStatus
    {
        Inactive = 0,
        Active = 10,
        Winner = 20
    }

    public enum AwardVoteStatus
    {
        Inactive = 0,
        Active = 10,
        Pending = 5,
    }

    public enum MediaUriType
    {
        Youtube = 1, Tudou = 0
    }

    public enum PrivateFlag
    {
        Public = 0,
        Private = 1
    }

    public enum CorpAccountStatus
    {
        Inactive = 0,
        Pending = 5,
        Active = 10
    }

    public enum AccountType
    {
        Free = 0,//partial
        Paid = 10,//full
        NonRMS = 20
    }


    public enum CorpUserRoleAccessLevel
    {
        RestaurantDataEdit = 1,
        CouponEdit = 4,
        ReviewEdit = 8,
        FoodnewsEdit = 16,
        ArticleEdit = 32,
        NoticeBoardEdit = 64,
        PhotoEdit = 128,
        VideoEdit = 256,
        MenuEdit = 512,
        UseOtherTools = 1024,
        JobEdit = 2048,
        ChainEdit = 16777216,   // 2^24
        UserEdit = 134217728,    // 2^27
        RMSAdmin = 150999037,
        Admin = 150997757
    }

    public enum CorpUserRoleStatus
    {
        Inactive = 0,
        Active = 10
    }

    // Feature Item's condition Key for sponsorlisting.
    public enum ConditionKey
    {
        Cuisine = 0,
        District = 1,
        Price = 2,
        Theme = 3,
        Amenity = 4,
        Dish = 5,
        //Special = 6,   // not in use
        Region = 7,
        Languange = 8,
        Keyword = 10,
        Landmark = 11,
        Group = 15,  // corp account
        Chain = 20,
        PoiId = 21,
        CuisineGroup = 22,
        DishGroup = 23,
        Condition = 24,
        JobCategory = 25, 
        JobCategoryGroup = 26, 
        Unconditional = 255 // for Run-of-site condition
        //Channel = 9   // not in use
    }

    public enum FeatureItemStatus
    {
        Inactive = 0,
        Active = 10
    }

    public enum FeatureItemBOStatus
    {
        Inactive = 0,
        Expired = 1,
        Future = 3,
        Active = 10
    }

    public enum ConditionOpr
    {
        Equal_To = 0,
        Not_Equal_To = 1,
        In = 2,
        Not_In = 3


    }

    public enum ConditionBoolean
    {
        AND = 0,
        OR = 1
    }

    public enum Codetable
    {
        //PriceType = 1,
        PhotoType = 2,
        //Price = 3,
        //Region = 4,
        //Special =5,
        MenuType = 6,
        DiningType = 7,
        Location = 11, // Region + Some more
        Age = 12,
        Gender = 13,
        Frequency = 14,
        Education = 15,
        CorpJobCareerLevel = 16,
        CorpJobEduLevel = 17,
        CorpJobSalaryType = 18,
        CorpJobEmploymentType = 19,
        CorpJobCategory = 20,
        MaritalStatus = 21,
        CareerLevel = 22,
        UserPoint = 23,
        MediaChannels = 24,
        DiningOfferType = 25,
        UserGrade = 26,
        MarketPlace = 27,
        UserTitle = 38,
        BirthYearRange = 39,
        RegisterCountry = 40,
        SearchOptionHighLight = 41,
        VendorOrderLogPayment = 42
    }

    public enum CodetableGender
    {
        Male = 1,
        Female = 2,
        Unavailable = -1
    }
    public enum CodetableUserTitle
    {
        Mr = 1,
        Ms = 2,
        Miss = 3,
        Mrs = 4,
        Unavailable = -1
    }

    public enum ProductStatus
    {
        Inactive = 0,
        Active = 10
    }

    public enum OrderStatus
    {
        Fail = 0,
        Pending = 5,
        Paid = 10,
        Delivered = 15,
        Collected = 20
    }

    public enum DeliveryMethod
    {
        SelfPick = 0,
        Mail = 1,
        RegisteredMail = 2
    }

    public enum GroupBuyDeliveryMethod
    {
        SelfPick = 0,
        Mail = 1,
        RegisteredMail = 2
    }

    public enum PaymentStatus
    {
        Failed = 0,
        Wait = 5,
        Success = 10,

    }

    public enum RegionStatus
    {
        inactive = 0,
        backofficeonly = 5,
        normal = 10,
        showonindex = 15,
        highlighted = 20
    }

    public enum Enum_CountryStatus
    {
        inactive = 0,
        normal = 10,
        showonindex = 15,
        highlighted = 20
    }

    public enum HomeRegionStatus
    {
        inactive = ORFramework.Models.CodeTabeStatus.Hide,
        normal = ORFramework.Models.CodeTabeStatus.Normal,
        group = ORFramework.Models.CodeTabeStatus.Group
    }


    public enum BOStatusReason
    {
        Normal = 0,
        ApproveSuspected = 1,
        RejectSuspected = 2,
        OnHoldSeriousComplaint = 3,
        OnHoldTastingEvent = 4,
        OnHoldORIssue = 5,
    }

    public enum CategoryStatus
    {
        Hide = ORFramework.Models.CodeTabeStatus.Hide,
        Normal = ORFramework.Models.CodeTabeStatus.Normal,
        Group = ORFramework.Models.CodeTabeStatus.Group,
        ShortListed = 15
    }

    public enum ConditionStatus
    {
        Inactive = 0,
        Active = 10,
        ShowAlways = 14,
    }

    public enum Enum_ConditionType
    {
        ConditionFromData = 1,
        ConditionFromLogic = 2
    }
    public enum Enum_ConditionIsSearchable
    {
        NotSearchable = 0,
        Searchable = 1
    }

    public enum Enum_CategoryType
    {
        Cuisine = 1, // restaurant
        Amenity = 3,
        Dish = 2, // restaurant
        Theme = 4

    }
    public enum Enum_IsShowInTM
    {
        Ticked = 1,
        Unticked = 0
    }

    public enum Enum_PoiType
    {
        DeactivatedForSnap = 255,    // Review Photo's PoiType, For Snap Sync Data Only
        Restaurant = 1,
        //Hotel = 2,        // reserved 2 for hotel and 3 for attraction in case need to merge ortravel db to openrice3 db.
        //Attraction = 3,   // reserved 2 for hotel and 3 for attraction in case need to merge ortravel db to openrice3 db.
        Retail = 10         // start with 10 just in case Retail needs to be split to smaller types e.g. wine, dried food, convenience store, luxury goods, which will use enum 11,12,13,14... also can split by using categories of this poitype
    }

    public enum DistrictStatus
    {
        Hide = ORFramework.Models.CodeTabeStatus.Hide,
        Normal = ORFramework.Models.CodeTabeStatus.Normal,
        Group = ORFramework.Models.CodeTabeStatus.Group,
        ShortListed = 15
    }

    public enum PoiStatus
    {
        Hide = 0,
        Closed = 1,
        //Others = 2,   //v1
        Normal = 10,
        Renovate = 3,
        Moved = 4,
        ChangedHands = 2,
        Delisted = 9
    }

    public enum PoiPendingApproveStatus
    {
        Normal = 10,
        Reject = 0,
        Approve = 1,
        OnHold = 2
    }

    public enum PoiPendingOperateType
    {
        Update = 0,
        New = 1,
        ChangeStatus = 2
    }

    public enum VideoUriType
    {
        Youtube = 1
    }

    public enum DataSyncErrorType
    {
        PullUser_Duplicate = 0,
        Push_Exception,
        Pull_Exception
    }

    public enum DataSyncTableType
    {
        Chain = 0,
        Poi,
        User,
        Coupon,
        Landmark
    }

    public enum CustomerType
    {
        No = 0,
        PaidCustomer = 1
    }

    public enum Enum_CustomViewStatus
    {
        Inactive = 0,
        Active = 10
    }

    public enum CMSContentStatus
    {
        Inactive = 0,
        Normal = 10
    }

    public enum UseMaster
    {
        UseStandard = 0,
        UseTemplate = 1,
        NoMaster = 2
    }

    public enum CMSContentPhotoType
    {
        Cover = 1,
        Logo = 2,
        Other = 3
    }

    public enum CMSSubContentStatus
    {
        Inactive = 0,
        Normal = 10
    }


    public enum UserGrade
    {
        NoLevel = 0,
        Level1 = 1,
        Level2 = 2,
        Level3 = 3,
        Level4 = 4,
        Level5 = 5,
        Level6 = 6,
        Level7 = 7,
        Level8 = 8,
        Level9 = 9,
        Level10 = 10
    }

    public enum CustomPopularTagType
    {
        Add = 1,
        Remove = 2
    }

    public enum Enum_UserTagStatus
    {
        Hide = 0,
        Delete = 1,
        PendingTypein = 2,
        PendingClick = 3,
        ReadyTypein = 4,
        ReadyClick = 5,
        Normal = 10
    }

    public enum Enum_UserTagType
    {
        User = 0,
        Review = 1
    }

    public enum Enum_UserTagBoReadStatus
    {
        Read = 1,
        UnRead = 0
    }

    public enum FullTextSearchMode
    {
        None = 0,
        Normal = 1,
        WithSoundex = 2
    }

    public enum Enum_RMS_ActionType
    {
        Add = 1,
        Remove = 2,
        Edit = 3
    }

    //For CorpActionLog TableId use
    public enum Enum_TableId
    {
        Poi = 1,
        RestaurantDetail = 2,
        CorpAccount = 3,
        RestaurantPending = 4,
        FoodNews = 5,
        //FoodNewsPhoto = 6,
        File = 7,
        Photo = 8,
        Review = 9,
        FileCategory = 10,
        CorpUser = 11,
        CorpJob = 12,
        CorpJobPackageCorpAccount = 13,
        BriefReview = 14,
        PoiDoc = 15,
    }

    public enum Enum_FoodNewsPhotoStatus
    {
        Inactive = 0,
        Active = 10
    }

    public enum Enum_FoodNewsType
    {
        FoodNews = 1,
        Notice = 2,
        OpenRiceNews = 3,
        NormalNotice = 4
    };

    public enum Enum_FileStatus
    {
        Inactive = 0,
        Deleted = Inactive,
        Preview = 1,
        Pending = 2,
        Reject = 3,
        Active = 10,
        Internal = 4
    }

    public enum Enum_FileCategoryStatus
    {
        Inactive = 0,
        Active = 10
    }

    //public enum Enum_FilePriority
    //{
    //    Corp = 10,
    //    Staff = 20,
    //    Member = 30,
    //    Guest = 40,
    //}

    public enum Enum_FileSource
    {
        guest = 5,
        userphoto = 9,
        user = 10,
        admin = 20,
        restaurant = 30,
    }

    public enum Enum_FileType
    {
        PoiExtraPhoto = 1,
        Menu = 2,
        FoodDelivery = 3,
        RMSCoverPhoto = 4,
        RMSChainBackgroundPhoto = 5,
        RMSChainCoverPhoto = 6,

        RMSCorpAccountBackgroundPhoto = 7,
        RMSCorpAccountCoverPhoto = 8,

        RMSCorpAccountLandmarkBackgroundPhoto = 9,
        RMSCorpAccountLandmarkCoverPhoto = 10,
        RMSCorpAccountLandmarkLogoPhoto = 11,

        NameCard = 12,
        TopicCoverPhoto = 13,
        TopicItemPhoto = 14,

        // Copied from API Project: OpenRice.Models.DataTypes.FileType
        MMSCorpAccountCampaignThumbnail = 21,
        MMSCorpAccountCampaignCoverPhoto = 22,
        MMSCorpAccountLandmarkMorePagePhoto = 23,
    }

    public enum Enum_UserPrefType  //for defining the user auto publish preference for FB
    {
        FBPublishApprovedReview = 1,
        ActivityFeed = 2,
        EmailFeedDefaultChecked = 3,
        EmailFeedDefaultUnchecked = 4,
        FBShareLikes = 5,
        FBShareBookmarks = 6,
        SinaWeiBoApprovedReview = 7,
        SinaWeiBoWantTo = 8,
        FBShareFollows = 9,
        MyPoiOfferNotification = 10,
        NearbyPoiOfferNotification = 11,
        MyBookmarkedDistrict = 13,
        MyBookmarkedCuisine = 14,
        EventInvitationNotification = 15,
        ActivityAndPromotionNotification = 16,

        //new opt-out option from v5.5.0
        MyBookingNotification = 17,
        MyOfferNotification = 18,
        AllPushNotification = 19,        // this is a top level on/off button for all notifications.

        BookmarkSort = 30,   // Sort order of user's bookmarks
        SimilarJobsNotification = 40
    }

    public enum Enum_ReviewRating
    {
        NoRating = 0,
        Rating1 = 1,
        Rating2 = 2,
        Rating3 = 3
    }


    public enum Enum_MyThemeStatus
    {
        Inactive = 0,
        Active = 10
    }

    public enum Enum_MyThemePermission
    {
        Public = 0,
        UserGrade1 = 1,
        UserGrade2 = 2,
        UserGrade3 = 3,
        UserGrade4 = 4,
        UserGrade5 = 5,
        UserGrade6 = 6,
        UserGrade7 = 7,
        UserGrade8 = 8,
        UserGrade9 = 9,
        UserGrade10 = 10,
        Private = 255
    }

    public enum Enum_DiningMethod
    {
        DineIn = 1,
        Takeaway = 2,
        Delivery = 3
    }

    public enum Enum_CorpActionImportance
    {
        Low = 0,
        High = 10,
    }

    public enum SeoRuleStatus
    {
        Inactive = 0,
        Active = 10
    }

    public enum Enum_CorpActionType : int
    {
        //Openrice - 1000
        OR_Review_Edit = 1000, //this goes first to prevent display OR_Min
        OR_Min = 1000,
        OR_Max = 1199,

        //RMS project - localhost:1200
        RMS_Min = 1200,
        RMS_Restaurant_Edit = 1210,
        RMS_Restaurant_Comment = 1211,
        RMS_Restaurant_CommentReply = 1212,
        RMS_Restaurant_ExtraInfoUpdate = 1213,
        RMS_Restaurant_UpdateDoorPhoto = 1214,
        RMS_Restaurant_DeleteDoorPhoto = 1215,

        RMS_Photo_EditCaption = 1220,
        RMS_Photo_Delete = 1221,
        RMS_Photo_Upload = 1222,

        RMS_File_Upload = 1230,
        RMS_File_Delete = 1231,
        RMS_File_EditCaption = 1232,
        RMS_File_Reorder = 1233,
        RMS_File_EditPoi = 1234,
        RMS_File_UploadPendingToActive = 1235,

        RMS_FileCategory_Add = 1240,
        RMS_FileCategory_Delete = 1241,
        RMS_FileCategory_Edit = 1242,

        RMS_FoodNewsPhoto_EditCaption = 1250,
        RMS_FoodNewsPhoto_Upload = 1251,
        RMS_FoodNewsPhoto_Delete = 1252,

        RMS_Notice_Add = 1260,
        RMS_Notice_Edit = 1261,
        RMS_Notice_Delete = 1262,

        RMS_Coupon_Add = 1270,

        RMS_CorpUserEdit = 1280,
        RMS_CorpUserAdd = 1281,

        RMS_CorpAccountUploadLogo = 1290,//RMS upload logo 25200
        RMS_CorpAccountDeleteLogo = 1300,//RMS Delete logo

        RMS_CorpJobAddJob = 1291,
        RMS_CorpJobDeactiveJob = 1291,
        RMS_CorpJobEditob = 1292,
        RMS_CorpAccountUpdateFromJob = 1293,
        RMS_CorpJobPackageCreditUsed = 1294,
        RMS_CorpJobActiveJob = 1295,
        RMS_CorpJobRepostJob = 1296,
        RMS_CorpJobDeleteJob = 1297,
        RMS_CorpJobSaveDraft = 1298,
        RMS_CorpAccountUploadCorpJobLogo = 1299,


        RMS_DeleteChainBgPhoto = 1400,


        RMS_Max = 2999,


        BO_Restaurant_Add = 3000,
        BO_Min = 3000,   //this goes first to prevent display BO_Min
        BO_Restaurant_Edit = 3001,
        BO_Restaurant_BatchEdit = 3002,

        BO_Notice_Add = 3010,
        BO_Notice_Edit = 3011,

        BO_File_Upload = 3020,
        BO_File_Edit = 3021,
        BO_File_BatchInactive = 3022,

        BO_FileCategory_Add = 3030,
        BO_FileCategory_Edit = 3031,

        BO_FoodNews_Add = 3040,
        BO_FoodNews_Edit = 3041,

        BO_CorpUserEdit = 3050,
        BO_CorpUserAdd = 3051,
        BO_CorpJobAdd = 3052,
        BO_CorpJobEdit = 3053,


        BO_Review_Edit = 3060,

        BO_UrlRedirect_Edit = 3070,
        BO_UrlRedirect_Add = 3071,

        BO_PoiDoc_Add = 3072,
        BO_PoiDoc_Edit = 3073,

        BO_Max = 3999,

        // RMS Lite - 4000 to 4999
        RMS_Lite_Min = 4000,

        RMS_Lite_Edit_Payment = 4001,
        RMS_Lite_Edit_Spending = 4002,
        RMS_Lite_Edit_SigDish = 4003,
        RMS_Lite_Edit_OpeningHour = 4004,
        RMS_Lite_Edit_Condition = 4005,

        RMS_Lite_Max = 4999
    }

    public enum Enum_ClickStreamPage : int
    {
        sr2 = 2000,
    }

    public enum Enum_ClickStreamSubPage : int
    {
        sr2_Index = 2001,
        sr2_Review = 2002,
        sr2_Photo = 2003,
        sr2_Media = 2004,
        sr2_File = 2005,
        sr2_Notice = 2006,
        sr2_Buffet = 2007,
        sr2_HotPot = 2008,
        sr2_Party = 2009,
        sr2_FoodDelivery = 2010,
    }

    public enum Enum_KeywordType : int
    {
        Review = 10,
        Poi = 20
    }

    public enum Enum_KeywordSubType : int
    {
        Review_Default = 10,
        Poi_Default = 20,
        Poi_cname = 21,
        Poi_caddr = 22,
        Poi_csign = 23,
        Poi_cpopulartag = 24,
        Poi_phone = 25,
        Poi_ctag = 26
    }

    public enum Enum_KeywordStatus : int
    {
        Inactive = 0,
        Normal = 10,
        Premium = 20,
    }

    public enum Enum_RMS_CorpJobStatus
    {
        Deleted = 0,
        Deactivated = 1,
        New = 2,
        Draft = 5,
        Active = 10
    }

    public enum Enum_RMS_CorpJobPackageCorpAccountStatus
    {
        Deactivated = 1,
        Active = 10
    }

    public enum Enum_RMS_CorpJobPackageStatus
    {
        Deactivated = 1,
        Active = 10
    }

    public enum Enum_RMS_CorpJobFlag
    {
        WithSensitiveWord = 7,
        WithSensitiveWordNIgnorediscrimation = 8,
        IgnoreDiscrimation = 9,
        Default = 10,
    }

    public enum Enum_GroupBuyOfferItemStatus
    {
        Deactivated = 1,
        Active = 10
    }

    public enum Enum_GroupBuyOfferPhotoStatus
    {
        Deactivated = 1,
        Active = 10
    }

    public enum Enum_GroupBuyOfferStatus
    {
        Deactivated = 1,
        Active = 10
    }

    public enum Enum_SearchGuideStatus
    {
        Inactive = 0,
        Active = 10
    }

    public enum Enum_SearchGuideType
    {
        Cuisine = 1,
        Dish = 2,
        Amenity = 3,
        Theme = 4,
        District = 5,
        Landmark = 6,
        Condition = 7,
        CuisineGroup = 11,
        DishGroup = 12,
        //AmenityGroup = 13,
        //ThemeGroup = 14,
        DistrictGroup = 15,
        LandmarkGroup = 16,
        ConditionGroup = 17,
        Keyword = 20
    }

    public enum Enum_IsEnableOneTransactionPerUser
    {
        Yes = 1,
        No = 0
    }

    public enum Enum_GroupBuyOrderStatus
    {
        Deactivated = 1,  //Change status in BO
        GroupBuyCancel = 3,  //Cancel when the groupbuy offer has not enough order
        RefundToUser = 4, // Refund to user, but paydollar still "Accepted"
        VoidInPaydollar = 5, // Void in Paydollar (if paydollar void, need to rerun update status to update, should set in scheduler)
        VoidInPaypal = 6, // Void in Paypal

        // When GroupBuy MinQuota is not hit (Hold payment)
        PrePaidBegin = 10, // Initiate the Order
        PrePaidPending = 11, // Payment gateway report payment success
        PrePaidPendingFail = 12, // Payment gateway report payment fail
        PrePaidPendingCancel = 13, // Payment gateway report payment cancelled
        PrePaid = 14, // DataFeed report payment success
        PrePaidFail = 15, // DataFeed report payment fail

        // After the GroupBuy MinQuota is hit
        PaidBegin = 20, // Initiate the Order
        PaidPending = 21, // Payment gateway report payment success
        PaidPendingFail = 22, // Payment gateway report payment fail
        PaidPendingCancel = 23, // Payment gateway report payment cancelled
        Paid = 24, // DataFeed report payment success
        PaidFail = 25, // DataFeed report payment fail
    }

    public enum Enum_GroupBuyOrderItemStatus
    {
        Deactivated = 1,
        Active = 10
    }

    public enum Enum_GroupBuyOfferPhotoType
    {
        Offer = 1,
        Provider = 2
    }

    public enum Enum_GroupBuySubscriptionStatus
    {
        Deactivated = 1,
        Active = 10
    }

    public enum Enum_UserPointType
    {
        AutoCalculation = 0,

        BookmarkPoi = 1,
        NewReviewNonPhoto = 2,
        NewReviewWithPhoto = 3,
        NewBriefReviewNonPhoto = 4,
        NewBriefReviewWithPhoto = 5,
        Login = 6,
        ReviewEditorsPick = 7,
        FirstReview = 8,
        Register = 9,
        RegisterViaFacebook = 10,
        FacebookMapAccount = 11,
        NewNonReviewNonPhoto = 12,
        NewNonReviewWithPhoto = 13,
        NewRestaurantPhoto = 14,
        ErrorReport = 15,
        CreateNewPoi = 16,
        UpdatePoi = 17,
        ClosePoi = 18,
        UserSubmitPoiPhoto = 19,
        AutoPublishReviewNonPhoto = 20,
        AutoPublishReviewWithPhoto = 21,
        AutoPublishFirstReview = 22
    }

    public enum Enum_UserPointStatus
    {
        Deactivated = 1,
        Active = 10
    }

    public enum Enum_BadgeStatus
    {
        Deactivated = 1,
        Active = 10
    }

    public enum Enum_UserPointTypeStatus
    {
        Deactivated = 1,
        Active = 10
    }

    public enum Enum_BadgeType
    {
        AwardCuisine = 1,
        AwardDistrict = 2
    }

    public enum Enum_PaymentType
    {
        PayDollar = 1,
        PayPal = 2,
        Alipay = 3
    }


    public enum Enum_ApiError
    {
        NoError = 200,

        InvalidCall = 40,
        InvalidMethod = 41,
        MissingParameter = 42,
        InvalidParameter = 43,

        InvalidApiToken = 44, /* invalid / expired */
        MissingApiToken = 45,
        InvalidApiSignature = 46,
        MissingApiSignature = 47,

        TooManyRequests = 48,

        InvalidAuthToken = 49,
        MissingAuthToken = 50,

        InvalidAppType = 51,
        InvalidAppVersion = 52,

        UserRegisterCountryNotMatchCountryCode = 53,

        PhotoUpload = 300,
        PhotoResize = 301,
        PhotoInfo = 302,

        ReviewAdd = 400,
        ReviewMealDate = 401,
        ReviewPrice = 402,
        ReviewWaitingTime = 403,
        ReviewBodyEmpty = 404,
        ReviewBodyLength = 405,
        ReviewTitleEmpty = 406,
        ReviewTitleLength = 407,
        ReviewAutoApprove = 408,
        ReviewAutoApproveEmail = 409,
        ReviewPhotoUpdate = 410,
        ReviewScoreSmile = 411,

        UserLogin = 500,
        UserLogout = 501,
        UserBookmarkDuplicated = 502,
        UserBookmarkAdd = 503,
        UserNotFound = 504,
        UserBookmarkPoiException = 505,
        UserBookmarkCouponException = 506,
        UserRegisterAlreadyLoggedIn = 507,
        UserRegisterBadUserName = 508,
        UserRegisterUserTitle = 509,
        UserRegisterHomeRegion = 510,
        UserRegisterBirthdayYearRange = 511,
        UserRegisterEmail = 512,
        UserRegisterEmailFormat = 513,
        UserRegisterEmailNotAvailable = 514,
        UserRegisterUserName = 515,
        UserRegisterUserNameFormat = 516,
        UserRegisterUserNameAllDigit = 517,
        UserRegisterUserNameNotAvailable = 518,
        UserRegisterFullName = 519,
        UserRegisterFullNameFormat = 520,
        UserRegisterPassword = 521,
        UserRegisterPasswordFormat = 522,
        UserRegisterException = 523,
        UserLoginWithFacebook = 524,
        UserPreferenceUpdate = 525,
        UserFacebookMapAccount = 526,
        UserLoginNonVerifyedAccount = 527,
        UserLoginDeactivatedAccount = 528,
        UserLoginSuspendedAccount = 529,
        UserLoginInvalidAccount = 530,
        UserLoginWrongUserNamePassword = 531,
        UserRegisterUserNameCharacterSet = 532,
        UserRegisterUserNameConsecutiveSpaces = 533,
        UserRegisterUserNameConsecutiveSpaces_tc = 535,
        UserRegisterUserNameConsecutiveSpaces_sc = 536,
        UserRegisterUserNameConsecutiveSpaces_th = 537,
        UserRegisterUserNameConsecutiveSpaces_id = 538,
        InvalidFacebookEmail = 534,

        UserFavouriteException = 541,

        SetUserInfoException = 551,

        UserInsertException = 561,

        UserLoginWithIM = 570,
        UserLoginWithFB = 571,  // Duplicated but reserved: UserLoginWithFacebook = 524
        UserLoginWithGPlus = 572,
        UserLoginWithQQ = 573,
        UserLoginWithSina = 574,
        UserLoginWithYahoo = 575,

        UserIMMapAccount = 580,
        UserFBMapAccount = 581,  // Duplicated but reserved: UserFacebookMapAccount = 526
        UserGPlusMapAccount = 582,
        UserQQMapAccount = 583,
        UserSinaMapAccount = 584,
        UserYahooMapAccount = 585,


        PoiNotFound = 600,

        CouponRedeem = 700,
        CouponNotFound = 701,
        CouponStatusNotForPurchase = 702,
        CouponExpired = 703,
        CouponNotYetStartedToBeOrdered = 704,
        CouponQuotaExceeded = 705,
        CouponUserQuotaExceeded = 706,
        CouponTotalAmountNotMatched = 707,
        CouponBuyerNotMatched = 708,
        CouponRedeemInvalidPasscode = 709,
        CouponStatusNotForRedeem = 710,

        CouponOrderAlreadyPaid = 720,
        CouponOrderNotFound = 721,
        CouponOrderUnableToReconfirm = 722,
        CouponOrderTimeout = 723,
        CouponOrderUserRealName = 724,
        CouponOrderDeliveryAddress = 725,

        InvalidPayPalToken = 730,
        InvalidCouponTotalAmount = 731,
        InvalidCouponOrderID = 732,
        InvalidCouponMaxIndex = 733,
        InvalidCouponID = 734,
        InvalidCouponOrderStatus = 735,
        InvalidCouponQuantity = 736,

        SendPushDeviceToken = 800,
        InvalidMemberEvent = 900,
        FailedToInsertMemberEventData = 901,

        Exception = 10000,

        // no need to implement a response in API, since the client will not receive API response if server maintenance.
        // just provide a static xml/json output format file with error status 20000 to infra team is ok.
        ServerMaintenance = 20000,
    }

    public enum Enum_ApiActionTypeId
    {
        GetWebsiteInfo,
        GetAppConfig,
        DoApiLogin,
        DoUserLogin,
        DoUserLogout,
        DoUserTablemapSsoLogin,
        DoUserTablemapSsoLogout,
        DoUserOpenRiceOtherDomainSsoLogin,
        DoUserOpenRiceOtherDomainSsoLogout,
        DoUserRegister,
        DoUserLoginWithFacebook,
        DoUserFacebookMapAccount,
        DoUserRegisterWithFacebook,
        DoUserLoginWithFacebookForSnap,
        DoUserFacebookMapAccountForSnap,
        DoUserRegisterWithFacebookForSnap,
        DoUserGetSsoTransitToken,
        DoUserLoginWithSSOToken,

        DoUserLoginWithGPlus,
        DoUserLoginWithGPlusforsnap,

        DoUserGPlusMapAccount,
        DoUserGPlusMapAccountforsnap,
        DoUserRegisterWithGPlus,
        DoUserRegisterWithGPlusforsnap,

        DoUserLoginWithQQ,
        DoUserQQMapAccount,
        DoUserRegisterWithQQ,

        DoUserLoginWithWeibo,
        DoUserWeiboMapAccount,
        DoUserRegisterWithWeibo,

        DoPoiSearch,
        DoPoiSearchForSnap,
        DoPoiSearchFaceted,
        DoPoiFullSearch,
        DoPoiNearbySearch,
        DoPoiNearbySearchForSnap,
        DoPoiNearBySearchForBlindUnion,
        DoPoiMapSearch,
        GetPoiDetail,
        GetPoiDetailForSnap,
        GetPoiReview,
        GetPoiReviewForSnap,
        GetReviewDetail,
        GetCharCountForReview,
        GetPoiPhoto,
        GetPoiSearchTip,
        GetPoiWidget,
        PostReportMap,
        DoCouponSearch,
        GetCouponDetail,

        GetRMSList,

        DoCouponRedeem,
        GetUserCouponOrderItemList,
        CouponPreCheck,
        CouponPayPalGetToken,
        CouponPayPalConfirm,

        DoPoiFacebookShare,
        GetBuffetPoiList,
        GetBuffetPoiDetail,
        GetBuffetPhoto,

        GetHotpotPoiList,
        GetHotpotPoiDetail,
        GetHotpotPhoto,

        GetHotNewsListing,
        GetHotNewsDetail,
        GetAllCodeList,

        GetCountryCodeList,
        GetRegionCodeList,
        GetDistrictCodeList,
        GetLandmarkCodeList,
        GetCategoryCodeList,
        //GetPriceCodeList,
        GetPriceRangeList,
        GetPriceTypeCodeList,
        GetBuffetPriceType,
        GetConditionCodeList,
        GetPhotoTypeCodeList,
        GetSpecialDayCodeList,

        GetWriteReviewCodeList,

        GetBuffetCategoryList,
        GetBuffetMinPriceRange,
        GetBuffetMaxPriceRange,
        GetBuffetTagList,

        GetHotpotCategoryList,
        GetHotpotMinPriceRange,
        GetHotpotMaxPriceRange,
        GetHotpotFoodList,
        GetHotpotConditionList,

        GetNightMarketListing,

        GetFeatureItemList,
        GetAdBanner,
        GetIndexItemList,

        DoPoiReviewSubmit,
        DoPoiReviewRatingUp,
        DoPoiPhotoSubmit,
        DoPoiPhotoRatingUp,
        GetUserInfo,
        GetMemberInfo,
        SetUserInfo,
        SetAvatarPhoto,
        SetCoverPhoto,
        DownloadFacebookAvatar,
        GetLoggedInUserInfo,

        GetFriend,
        AddFriend,

        CheckBookmarkExist,
        GetBookmarkRestaurant,
        DoBookmarkRestaurantSubmit,
        DoBookmarkRestaurantShare,
        GetBookmarkCategory,
        DeleteBookmarkRestaurant,
        AddIsWantGo,
        AddHaveBeenToGo,
        GetBookmarkCoupon,
        DoBookmarkCouponSubmit,
        DeleteBookmarkCoupon,

        GetBookmarkBP,

        UpdateFavourite,

        SetUserPrefs,
        SetUserPrefsFacebookPublishShare,

        ContactUs,

        ReviewList,
        UserDevice,
        TopRestaurants,
        NewRestaurants,
        JumpRestaurants,

        ForgetPassword,

        GetAsiaDiningSearchOptionList,
        GetAsiaDiningSponsorList,
        GetAsiaDiningRegionList,
        GetAsiaDiningPoiList,

        GetNavContent,

        GetTMOffers,
        GetTMFeatureItems,

        DoBookmarkUserSubmit,

        SendPushDeviceToken,

        DoReviewCommentSubmit,
        DoReviewReplySubmit,
        DoPhotoCommentSubmit,
        DoPhotoReplySubmit,
        DoVideoCommentSubmit,
        DoVideoReplySubmit,
        DoRecipeCommentSubmit,
        DoRecipeReplySubmit,
        DoArticleCommentSubmit,

        UnDoPoiReviewRatingUp,
        UnDoPoiPhotoRatingUp,
        DoRecipeRatingUp,
        UnDoRecipeRatingUp,

        //-- MyOR ActivityFeed
        MyOrActivityFeedRecipeDetail,
        MyOrActivityFeedFoodNewsDetail,
        MyOrActivityFeedUserDetail,
        MyOrActivityFeedReviewDetail,
        MyOrActivityFeedBbs,
        MyOrActivityFeedRecipeComment,
        MyOrActivityFeedReviewComment,
        MyOrBBSCreate,
        MyOrBBSDelete,
        MyOrPendingReviewDelete,
        MyOrActivityFeedGetArticleList,
        MyOrActivityFeedPoiDetail,

        CheckMultiReviewRating,
        CheckAnyPoi,
        CreateBPCategory,
        DeleteBPCategory,
        UpdateBPCategory,
        InsertBriefReview,

        //-- Member Event
        ORMemberEventGetList,
        ORMemberEventGetDetail,
        ORMemberEventPhotoGetList,
        ORMemberEventSignUp,
        ORMemberEventUserGetList,

        //-- Gruoped Home Region
        GetGruopedHomeRegion,
        //-- New Get Search Tips
        GetSearchTipsAllowNearby,

        ApiError = 999
    }

    public enum Enum_iPhoneSubChannel
    {
        iPhoneCouponListing = 6
    }

    /// <summary>
    ///OAuthConnect数据返回类型
    /// </summary>
    public enum Enum_DataFormatEnum
    {
        /// <summary>
        /// 以 xml 文本形式返回
        /// </summary>
        Xml,

        /// <summary>
        /// 以Json 字符串形式返回
        /// </summary>
        Json
    }

    public enum Enum_RestaurantPending_Info
    {
        NoInformation = 0,
        Yes = 1,
        No = 2
    }

    public enum Enum_SiteMessageStatus
    {
        Normal = 10,
        inactive = 0,
        New = 11
    }

    public enum Enum_SiteMessageType
    {
        Send = 0,
        Recive = 1,
        Remind = 2,
        System = 3
    }

    public enum Enum_SysSiteMessageStatus
    {
        Reminded = 0,
        Readed = 1,
        Delete = 2
    }



    public enum Enum_RemindType
    {
        ReviewComment = 1,
        PhotoComment = 2,
        ReviewVote = 3,
        PhotoVote = 4,
        BookmarkUser = 5,
        BBS = 6,
        ReviewRating = 7,
        BriefReviewVote = 8,
        UserGrade = 9,
        ReviewReject = 10,
        ReviewApproval = 11,
        ReviewDeactivate = 12,
        BriefReviewDeactivate = 13,
        PhotoReject = 14,
        PhotoApproval = 15,
        MenuReject = 16,
        MenuApproval = 17,
        ReviewCommentReply = 18,
        PhotoCommentReply = 19,
        BBSReply = 20,
        ReviewCommentRemind = 21,
        PhotoCommentRemind = 22,
        BBSRemind = 23,
        ReviewApprovalRecommend = 24,
        ReviewRecommend = 25,
        BlackoutTime = 26,
        CouponRemindWant = 27,
        CouponRemindGo = 28,
        UserTagComment = 29,
        PoiApproval = 30,
        PoiUpdate = 31,
        PoiClose = 32,
        ReviewPhotoApproval = 33,
        RecipeApproval = 34,
        RecipeReject = 35,
        RecipeCommentReply = 36,
        ArticleCommentReply = 37,
        MShowCommentReply = 38,
        ActivityCommentReply = 39,
        PoidRenovateByUser = 40,
        PoiCloseByUser = 41
    };

    public enum Enum_SeoKeywordStatus
    {
        Normal = 10,
        Inactive = 0
    }

    public enum Enum_SeoKeywordType
    {
        CombinationWord = 1,
        Keyword = 0
    }


    public enum Enum_PoiOrChainType
    {
        Chain = 0,
        Poi = 1
    }

    public enum Enum_MobileBrand
    {
        //Google, HTC, Samsung, LG, Sony Ericsson, Motorola, Acer
        Google = 1,
        HTC = 2,
        Samsung = 3,
        LG = 4,
        Sony_Ericsson = 5,
        Motorola = 6,
        Acer = 7,
        Apple = 8
    }

    public enum Enum_MobileStatus
    {
        enable = 1,
        disable = 0
    }

    public enum Enum_DeviceTypeId
    {
        Android = 1,
        Iphone = 2,
        BlackBerry = 3,
        WindowsPhone = 4,
        MobileWeb = 5,
        iPhoneAndroid = 6
    }

    public enum Enum_MobileAppId
    {
        IPhoneMain = 1,
        AndroidMain = 2,
        IPhoneSnap = 3,
        AndroidSnap = 4
    }

    public enum Enum_MobileIndexIconsActionType
    {
        SectionHeader = 0,
        AdvSearch = 1,
        Nearby = 2,
        Bookmark = 3,
        Coupon = 4,
        TableMapReservation = 5,
        Award = 6,
        Chart = 7,
        RandomSearch = 8,
        AmericanExpress = 9,
        Hotpot = 10,
        Buffet = 11,
        HotNewsListing = 12,
        Xmas = 13,
        LatestReview = 14,
        SnapShare = 15,
        WebLink = 16,
        RestaurantDetail = 17,
        CouponDetail = 18,
        MyOpenRice = 19,
        Home = 20,
        QRScanner = 21,
        MyCoupons = 22,
        Settings = 23,
        Chain = 24,
        HotNewsDetail = 25,
        OpenSnap = 26
    }

    public enum Enum_MobileIndexSlideType
    {
        LatestReview = 0,
        Coupon = 1,
        RestaurantChart = 2,
        Nearby = 3,
        HotNews = 5,
        Custom = 60,
    }

    public enum Enum_MobileIndexTemplateId
    {
        TopSpan = 1,
        LeftSpan = 2,
        Divided = 3,
        Single = 4
    }

    public enum Enum_ConfigTypeId
    {
        Access = 1
    }

    public enum Enum_MEventTypeId
    {
        FreeEat = 1,
        OpenriceShow = 2,
        Award = 3
    }

    public enum Enum_PushNotificationTypeId
    {
        Marketing = 1,
        SalesSupport = 2,
        Member = 3,
        Usage = 4,
        Seasonal = 5,
        RestaurantOffer = 6,
        Article = 7,
        CustomerRelationship = 8
    }

    public enum Enum_PushNotificationLinktoTypeId
    {
        URL = 1,
        Other = 2
    }

    public enum Enum_PushNotificationStatus
    {
        Inactivate = 0,
        WaitingToSend = 1,
        Sending = 2,
        Sent = 3,
        Failure = 4
    }

    public enum Enum_PushNotificationDestinationType
    {
        Unspecified = 0, /* For old app, destination type would be null of 0 */
        Homepage = 1,
        AdvSearch = 2,
        NearbySR1 = 3,
        BuffetSR1 = 4,
        HotpotSR1 = 5,
        ReservationSR1 = 6,
        RestaurantChart = 7,
        Reserved1 = 8, /* Should not use this as this will affect vendor progress */
        HotNews = 9,
        HotOffersSR1Coupon = 10,
        HotOffersSR1Voucher = 11,
        LatestReviewsSR1 = 12,
        MyOpenRice = 13,
        MyBookmarks = 14,
        MyWalletBookmarked = 15,
        MyWalletPurchased = 16,
        Settings = 17,
        OpenUrlInApp = 18,
        OpenUrlWithBrowser = 19,
        FeaturedRestaurant = 20,
        FeaturedCoupon = 21,
        FeaturedItemID = 22,
        //OthersOpeninAppInputURL = 23,
        //OthersOpeninSafariInputURL = 24
        PoiSR2 = 25,
        Article = 33,
        CMS = 34,
        ImportFile = 35
    }

    public enum Enum_ActivityFeedStatus
    {
        Inactivate = 0,
        //Read = 5,

        Activate = 10
    }

    public enum Enum_PushNotificationIsPublic
    {
        InternalUser = 0,
        Public = 1,
    }


    public enum Enum_UserDeviceStatus
    {
        Inactivate = 0,
        Activate = 10,
        InternalUser = 20,
    }

    public enum Enum_ActivityCategoryStatus
    {
        Deactivate = 0,
        Activate = 10
    }

    //public enum Enum_FoodNewsCategory
    //{
    //    OpenriceNews = 1,
    //    RestaurantNews = 2,
    //}
    public enum Enum_ActivityCategoryType
    {
        All = 0,
        Personal = 1,
        Restaurant = 2,
        OR = 3,
        Overview = 4
    }

    public enum Enum_ActivityCategory
    {
        Min_Personal = 0,
        bookmark_review_comment = 20,

        review_new_comment = 30,
        reply_to_review_comment1 = 35,
        reply_to_review_comment2 = 40,
        new_comment_from_owner = 50,
        reply_to_owner_comment = 60,
        reply_to_comment_from_owner = 70,
        review_recommend = 80,
        new_fan = 90,
        new_bbs = 100,
        review_editor_choice = 110,
        feature_gourmet = 120,
        recipe_comment = 130,
        level_up = 140,
        bookmark_gourmet_review = 150,
        bookmark_gourmet_bookmark_rest = 160,
        bookmark_gourmet_recommend_review = 170,
        bookmark_gourmet_travel = 175,//no activityfeed
        bookmark_gourmet_fan = 180,

        travel_comment = 200,//no activityfeed
        bookmark_gourmet_bookmark_restaurant = 210,
        bookmark_gourmet_birthday = 220,
        gourmet_birthday = 230,

        Max_Personal = 9999,

        Min_Restaurant = 10000,

        bookmark_restaurant_coupon = 10010,
        bookmark_restaurant_news = 10020,
        bookmark_restaurant_status = 10030,
        preference_restaurant_info_living_area = 10040,
        preference_restaurant_info_working_area = 10045,
        preference_restaurant_info_favorite_food = 10050,
        preference_restaurant_info_hangout = 10055,
        preference_restaurant_info_favorite_type = 10060,
        preference_restaurant_info_cuisine = 10065,
        preference_coupon_living_area = 10070,
        preference_coupon_working_area = 10075,
        preference_coupon_favorite_food = 10080,
        preference_coupon_favorite_cuisine = 10085,
        preference_coupon_favorite_type = 10090,
        preference_coupon_favorite_hangout = 10095,


        Max_Restaurant = 19999,

        Min_OR = 20000,


        bookmark_restaurant_article = 20002,
        mkt_msg = 20004,
        new_groupbuy = 20006,
        bookmark_restaurant_headline = 20008,



        Max_OR = 29999,

        following_bookmark_gourmet_review = 30002,
        following_bookmark_g_recommend_review = 30004,
        following_bookmark_gourmet_fan = 30008,
        following_bookmark_g_bookmark_restaurant = 30012,

        like_photos = 30014,
        new_photos = 30015,
        new_video = 30018
    }
    public enum Method { GET, POST, PUT, DELETE };

    public enum SignatureTypes
    {
        HMACSHA1,
        PLAINTEXT,
        RSASHA1
    }

    public enum Enum_ReviewSubmitSource
    {
        Unknown = 0, // Default value in DB
        Desktop = 1,
        WAP = 2,
        IPhoneApp = 3,
        AndroidApp = 4,
        NokiaApp = 5,
        BlackBerryApp = 6,
        BloggerTool = 11
    }

    public enum LogQueryStatus
    {
        Inactive = 0,
        Pending = 5,
        Sent = 10
    }

    public enum LogQueryType
    {
        Member = 1

    }

    public enum Enum_ActivityCategoryFromSource
    {
        user = 10,
        admin = 20,
        restaurant = 30
    }

    public enum Enum_ActivityFeedEmailStatus
    {
        Inactive = 0,
        Fail = 1,
        Pending = 5,
        Sent = 10
    }

    public enum Enum_ScheduleTask
    {
        //Site
        CreateRanking = 101,
        CreateUserRanking = 102,
        ScanUserGradeLevelUp = 103,
        UpdateFooterStats = 104,
        PoiPopularTagGen = 105,
        GroupBuyCapturePaymentCurrentOfferProcess = 106,
        GroupBuyEndOfOfferProcess = 107,
        ImpressClickRollUp = 108,
        ImportCorpJob = 109,

        ScheduleLogMonitor = 110,
        GeneratePoiSearchTips = 111,
        GetTMFeatureItems = 112,
        GetTMOffers = 113,
        RecalcPoiTagSearch = 114,
        RecalcModifiedPoiTagSearch = 115,
        UpdateNewChainPoiModifyTime = 116,
        UserConflict = 117,
        UpdatePoiIsPaidAccount = 118,
        GeneratePhotoInfo = 119,
        DeletePoiSearchTipsForDeletedChains = 120,
        ReviewViewCountIncrement = 121,
        FillLandmarkPoi = 122,
        ActivityFeedEmail = 150,
        RecalculateAllMissingGeoAreaPois = 151,
        RecalculateUserFanCountIdolCount = 152,
        UpdateUserBlackoutTime = 153,
        UpdateActivePoiTMPoiId = 154,
        UpdateActiveEat365Pois = 155,
        UpdateTMPoiService = 156,
        UpdateReviewVerifiedService = 157,
        UpdateActiveSpotPaymentPois = 158,
        UpdateActiveEmenuPois = 159,
        UpdateActiveTakeawayPois = 160, // Continue ids in 180

        CouponOrderCancelTimedOutOrders = 161,
        DeleteTestUploadPhotos = 162,

        UpdateUserBadWordLandmark = 163,

        GenerateDoorPhotoList = 164,

        GenerateYahooFeedAllPois = 170,
        GenerateYahooFeedAllPoisV3 = 171,
        AppleMapsDataBaseAndRich = 172,
        AppleMapsDataPhotoAndReview = 173,
        AppleMapsToAWSS3 = 174,

        // Continue vendorpoi sync jobs
        UpdateActiveDineInPois = 180,
        UpdateActiveTakeawayPoisAllVendors = 181,
        UpdateActiveVendorPoiService = 182,

        //Marketing
        MonthlyEnews = 201,
        GenerateEmailBlastList = 202,
        SendEmailForMemberQuery = 203,
        GenerateExpiringRestaurant = 220,

        //External
        ExportXmlDataForGarmin = 301,
        ToCentamap = 302,
        ToGoogle = 303,
        ExportTo88DB = 304,
        CreateSiteMapRest = 305,
        CreateSiteMapReview = 306,
        ToNokia = 307,
        CreateSiteMapArticle = 308,
        CreateSiteMapRestMobile = 309,
        CreateSiteMapRestPhoto = 310,
        CreateSiteMapCoupon = 311,
        CreateImageSiteMapRestPhoto = 312,
        CreateSiteMapDistrict = 313,
        CreateSiteMapCategory = 314,

        //Biz
        SendMerchantBRExpiryNotice = 401,

        //activityfeed

        bookmark_gourmet_travel = 1001,
        bookmark_review_comment = 1020,
        travel_comment = 1030,
        review_new_comment = 1040,
        reply_to_review_comment1 = 1050,
        reply_to_review_comment2 = 1060,
        new_comment_from_owner = 1070,
        reply_to_owner_comment = 1080,
        reply_to_comment_from_owner = 1090,
        review_recommend = 1100,
        new_fan = 1110,
        new_bbs = 1120,
        review_editor_choice = 1130,
        feature_gourmet = 1140,
        recipe_comment = 1150,
        level_up = 1160,
        bookmark_gourmet_review = 1170,
        bookmark_gourmet_bookmark_rest = 1180,
        bookmark_gourmet_recommend_review = 1200,
        bookmark_gourmet_fan = 1300,
        bookmark_gourmet_bookmark_restaurant = 1400,
        bookmark_restaurant_coupon = 1500,
        bookmark_restaurant_news = 1600,
        bookmark_restaurant_status = 1700,
        preference_restaurant_info_living_area = 1800,
        preference_restaurant_info_working_area = 1900,
        preference_restaurant_info_favorite_food = 2000,
        preference_restaurant_info_hangout = 2100,
        preference_restaurant_info_favorite_type = 2200,
        preference_restaurant_info_cuisine = 2300,
        preference_coupon_living_area = 2400,
        preference_coupon_working_area = 2500,
        preference_coupon_favorite_food = 2600,
        preference_coupon_favorite_cuisine = 2700,
        preference_coupon_favorite_type = 2900,
        preference_coupon_favorite_hangout = 3000,
        bookmark_restaurant_article = 3100,
        mkt_msg = 3200,
        new_groupbuy = 3300,
        bookmark_restaurant_headline = 3400

    }
    public enum Enum_ActivityFeedDisplayStatus
    {
        Deactivate = 0,
        Activate = 10
    }

    public enum Enum_BadNameType
    {
        FirstLevel_ORShop = 10,
        FirstLevel_Marketing = 20,
        FirstLevel_Sales = 30
    }

    public enum Enum_BadNameStatus
    {
        Normal = 10
    }

    public enum Enum_UrlRedirectType
    {
        FirstLevel_ORShop = 10,
        FirstLevel_Marketing = 20,
        FirstLevel_Sales = 30,
        SecondLevel_Marketing = 200
    }

    public enum Enum_dinningOffer
    {
        dinningOfferRemark = ORLibrary.Models.ApplicationData.DINNING_OFFER_OTHER_ID,
        dinningOfferCoupon = 256
    }

    public enum Enum_SearchTipType
    {
        Poi = 0,
        Chain = 1,
        UserRecommendDish = 2,
        SignatureDish = 3,
        District = 4,
        Landmark = 5,
        Cuisine = 6,
        Dish = 7,
        Amenity = 8,
        Theme = 9,
        CorpAccount = 10
    }

    public enum Enum_PoiThemeStatus
    {
        Inactive = 0,
        Active = 10,
    }

    public enum Enum_TMYearOfferPromotion
    {
        MinPromotionId = 1000,
        MaxPromotionId = 2000
    }

    public enum Enum_TMRestaurantWeek
    {
        PromotionId = 3000
    }


    public enum Enum_IMType
    {
        None = 0, //v5 added
        QQ = 1,
        Sina = 2,
        Facebook = 3,
        Yahoo = 4,
        GooglePlus = 5,
        AppleID = 6,
        PartnerAlipayBooking = 20,
        PartnerAlipayVoucher = 21,
        PartnerAlipayCNAward = 22,
        PartnerAlipayCN_MiniProg = 23,
        PartnerAlipayHK_MiniProg = 24,
        PartnerAlipayCN_ShowCase = 25,
        PartnerAsiamiles = 30,
        PartnerAml = 31,
        PartnerHsbcRewardPlus = 40,
        PartnerIcbc = 50,
        PartnerCtrip = 60,
        PartnerHysan = 70,
        PartnerTaiKoo = 90,
    }

    public enum Enum_RegisterMethod
    {
        Email = 1,
        Phone = 2,
        Facebook = 3,
        Google = 4,
        TableBooking = 5
    } 

	//User registersource
    //ordw report use this enum
    public enum Enum_UserSource
    {
        ////Web = 1,
        ////WAP = 2,
        ////Console=3,

        TMWeb = 1,
        TMConsole = 2,
        TMTMS = 3,
        TMWAP = 4,//MOBILE
        TMAndroid = 5,
        TMIphone = 6,
        TMWP = 7,
        TMWidget = 8,
        ORWeb = 10,
        ORWAP = 15,
        ORIphone = 13,
        ORAndroid = 14,
        ORMobileWeb = 16,

        TravelWeb = 20,

        Foodpanda = 25,

        SnapIPhone = 30,
        SnapAndroid = 31,
        SnapDesktopWeb = 32,
        SnapMobileWeb = 33,

        Alipay = 40,
        AlipayCN = 41,

        Icbc = 50,
        Ctrip = 60
    }

    public enum Enum_PhoneConfirmStatus
    {
        NoPhoneInput = 0,
        Pending = 5,
        PhoneOwnerChange = 7, // User's phone number is no longer valid because it's associated with another user.
        active = 10,
    }

    public enum Enum_Sr1PoiBlock
    {
        Normal = 0,
        Sponsor = 1,
        New_Full = 2,
        New_Half = 3
    }
    public enum Enum_SeoSr2ActionName
    {
        menu,
        review,
        briefreview,
        photo,
        video,
        map
    }

    public enum Enum_CouponOrderPayPalStatus
    {
        None = 1, //No status.
        CanceledReversal = 3, //A reversal has been canceled. For example, when you win a dispute, PayPal returns the funds for the reversal to you.
        Denied = 6, // The payment has been completed, and the funds have been added successfully to your account balance.
        Completed = 4, // You denied the payment. This happens only if the payment was previously pending because of possible reasons described for the PendingReason element.
        Expired = 20, // The authorization period for this payment has been reached.
        Failed = 21, // The payment has failed. This happens only if the payment was made from the buyer’s bank account.
        InProgress = 22, // The transaction has not terminated. For example, an authorization may be awaiting completion.
        PartiallyRefunded = 24, // The payment has been partially refunded.
        Pending = 25, //  The payment is pending. See the PendingReason field for more information.
        Refunded = 27,// You refunded the payment.
        Reversed = 29,// A payment was reversed due to a chargeback or other type of reversal. PayPal removes the funds from your account balance and returns them to the buyer. The ReasonCode element specifies the reason for the reversal.
        Processed = 33,// A payment has been accepted.
        Voided = 40// An authorization for this transaction has been voided.

    }

    public enum Enum_CouponOrderStatus
    {

        Deactivated = 1, // Internal staff has cancelled this transaction due to some reasons
        //CouponCancel = 3, // The coupon has been cancelled
        RefundToUser = 4, // Internal staff has refunded to the users for a completed payment
        VoidInPaypal = 6, // Internal staff has voided the transaction in PayPal due to some reasons
        FreeCouponRedeemed = 7, // While redeeming free coupon, create a new CouponOrder and 

        //                        // set status to redeem immediately. Not visible in Paid Coupon section in BO.

        PaidBegin = 20, // Users started payment process (i.e. enter the payment gateway)

        PaidPending = 21, // Users completed payment (i.e. redirect back to the coupon SR1) but system have not yet received any gateway’s feedback
        PaidCancel = 22, // Users started payment process (i.e. enter the payment gateway), but cancelled or terminated the transaction in the gateway

        Paid = 24, // Users completed payment and system have received the gateway’s success feedback
        PaidFail = 25, // Users completed payment but system have received the gateway’s failure feedback       


        //todo will delete following value later
        //PaidPendingFail = -1,
        //PaidPendingCancel = -2,
        //FreeCouponRedeemed = -3

    }




    public enum Enum_CouponOrderItemStatus
    {
        Normal = 5,
        Redeem = 10,
        Redeemed = 10

    }

    public enum Enum_CouponRedeemMethod
    {
        Print = 1,
        ShowMobile = 5,
        QRinApp = 10,
        Mail = 15,
        Walkin = 20,
        Card = 25,

        //coupon sync from TM biz:
        Discount = 26,
        LastMins = 27,
        Standalone = 28,
        Retention = 29,
        TMCampaign = 30,
        MarketingOffer = 31,
        YearRoundOffer = 32,
        CashVoucher = 33,
        LimitedOffer = 34,

        // Copied from API project: OpenRice.Models.DataTypes.CouponRedeemMethod
        PrepaidOffer = 35,
        HsbcOffer = 36,
        AsiaMilesFreeText = 37
    }

    public enum Enum_CouponIsChain
    {
        No = 0,
        Yes = 1
    }

    public enum Enum_CouponRedeemCodeTypeId
    {
        No = 0,
        SingleCode = 5,
        CodeEachPoi = 10
    }

    public enum Enum_CouponType
    {
        FreeCouponMobile = 1,
        FreeCouponPrintOut = 2,
        FreeCouponMobileApp = 3,
        PaidCouponMobileApp = 4,
        PaidCouponHardCopy = 5,
        WalkinCoupon = 6
    }

    // To indicate whether it is our customer (pay us to show their promotion)
    public enum Enum_PromotionType
    {
        Card = 1,
        ContentSponsor = 2,
        TMYearRound = 3,
    }

    public enum Enum_SliderStatus
    {
        Inactive = 0,
        Active = 10,
    }

    //public enum Enum_SlideType
    //{
    //    Nearby = 1,
    //    Coupon = 2,
    //    RestaurantChart = 3,
    //    Advertorials = 4,
    //    LatestReview = 5,
    //    Custom = 10
    //}

    //public enum Enum_Platform
    //{
    //    iPhone = 0,
    //    Android = 1
    //}

    public enum Enum_SnapPhotoStatus
    {
        Deactivated = 0,
        DeletedByUser = 1,
        Timeout = 3, /* Flagged to this if the full photo is not uploaded within X minutes, after the thumbnail uploaded */
        Uploading = 5,  //ThumbnailUploaded
        Active = 10,
    }

    public enum Enum_BadWord
    {
        Badnames = 1,
        UserBadwords = 2,
        Words = 3
    }

    public enum Enum_MembershipStatus
    {
        Activated = 1,
        Deactivated = 2,
        Unlocked = 3
    }

    public enum Enum_BPCat
    {
        WishToGo = 6,
        BeenHere = 7,
        BookMark = 8
    }

    public enum Enum_RMSChainBgType
    {
        UploadPhotos = 1,
        BackgroundColor = 2,
        Default = 3
    }

    public enum Enum_PoiIsPaidAccount
    {
        Inactive = 0,
        Active = 1
    }

    public enum Enum_BookmarkPoiAction
    {
        FromReview = 901,
        FromBriefReview = 902,
        FromClick = 903
    }

    public enum Enum_CorpAccountSr1Status
    {
        No = 0,
        Yes = 10
    }

    public enum Enum_CorpAccountConfigStatus
    {
        Deactivated = 0,
        Activated = 10,
    }

    public enum Enum_MobileDesktopRedirect
    {
        Index = 1,
        Sr1 = 2,
        Sr2 = 3,
        Sr2Map = 4,
        Sr2Reviews = 5,
        Sr2ReviewDetail = 6,
        Sr2Photos = 7,
        Sr2PhotoDetail = 8,
        Sr2Notice = 9,
        Coupons = 10,
        CouponDetail = 11,
        LatestReviews = 12,
        Login = 13,
        Registration = 14,
        //ForgotPassword = 15,
        AboutUs = 16,
        ContactUs = 17,
        //Settings = 18,
        //MyBookmarkedRestaurants = 19,

        BuffetListing = 20,
        BuffetDetail = 21,
        SearchBuffet = 22,
        HotpotListing = 23,
        HotpotDetail = 24,
        SearchHotpot = 25,
        Ranking = 26,
        ArticleDetail = 27,
        LatestArticles = 28,
        TopicalListing = 29,
        TopicalDetail = 30,
        Logout = 31
    }
    public enum Enum_ExcelWorkbookFormat
    {
        Xls_2003 = 2003,
        Xlsx_2007 = 2007
    }

    public enum Enum_ExcelValueType
    {
        IsNumber,
        IsDateTime,
        IsString
    }

    public enum Enum_ImportExcelTypeId
    {
        Poi = 1
    }

    public enum Enum_ImportExcel
    {
        MaxColumn = 130
    }

    public enum Enum_ImportExcelInfoType
    {
        InvalidInput = 1,
        ReferenceNotFound = 2,
        IncorrectSetup = 3,
        InvalidHeader = 4,
        PoiInsert = 10
    }

    public enum Enum_ImportExcelColumnType
    {
        Null = 0,
        TinyInt = 1,
        SmallInt = 2,
        Int = 3,
        Real = 4,
        Float = 5,
        String = 6,
        DateTime = 7,
        XML = 8,
        Ref = 9,
        Enum = 10,
        DistrictId = 20,
        RegionId = 30,
        LandmarkId = 40,
        CategoryIdByCusine = 51,
        CategoryIdByDishes = 52,
        CategoryIdByAmenity = 53,
        CategoryIdByTheme = 54,
        PaymentId = 60,
        ConditionId = 70
    }

    public enum Gourmet_HeadlinesType
    {
        NewbiesChart = 1,
        DistrictReviewChart = 2,
        FavouriteCategoryChart = 3,
        BirthdayUser = 4,
        UpgradeUser = 5,
        FeatureUser = 6,
        PopularUser = 7,
        FirstEditorRecmReviewUser = 8
    }

    public enum Gourmet_WidgetStyle
    {
        news = 1,
        block = 2
    }

    public enum Enum_ReviewEdit
    {
        No = 0,
        Yes = 1
    }



    public enum Enum_RMSPoiTemplateDataHtmlType
    {
        Disabled = 1,
        HalfHTMLBlock = 2,
        FullHTMLBlock = 3,
    }

    public enum Enum_ORSite
    {
        Unspecified = -1,
        HK = 0,
        CN = 1,
        TW = 90,
        ID = 100,
        PH = 200,
        SG = 300,
        TH = 400,
        MY = 500,
        IN = 600,
        JP = 800
    }

    public enum Enum_UserBadwordType
    {
        Default = 0,
        Landmark = 1
    }

    public enum Enum_SearchTipTypeWeight
    {
        CorpAccount = 10,
        Others = 0
    }

    public enum Enum_ActivityFeedItemType
    {
        None = 0,

        User = 1,
        Poi = 2,
        Review = 3,
        Coupon = 4,
        FoodNews = 5,
        Article = 6,
        Recipe = 7,
        BBS = 8,

        ReviewComment = 21,
        RecipeComment = 22
    }

    public enum Enum_UserPageBgPos
    {
        FullWidth = 0,
        Center = 1,
        Left = 2,
        Right = 3

    }

    public enum Openricer_HighlightType
    {
        Birthday = 0,
        TopRanking = 1,
        Feature = 2,
        Popular = 3,
        EditorRecmReview = 4,
        Upgrade = 5
    }

    public enum Enum_GeoSystem
    {
        WGS84 = 0, // World Geodetic System (WGS-84)
        GCJ02 = 1, // Mars Geodetic System (GCJ-02)
        BD09 = 2, // Baidu Geodetic System (BD-09)
    }

    public enum Enum_TopicStatus
    {
        Inactive = 0,
        Active = 10,
        Hidden = 15
    }

    public enum Enum_TopicItemType
    {
        Poi = 1,
        Chain = 2,
    }

    public enum Enum_TopicItemPhotoType
    {
        DoorPhoto = 0,
        Photo = 1,
        File = 2,
    }

    public enum Enum_HKTBSourceType
    {
        OpenRice = 1,
        Michelin = 2
    }

    public enum ShortenUrlReferenceType
    {
        Restaurant = 1,
    }
    public enum Enum_CategoryGroupType
    {
        Cuisine = 1,
        DishAndAmenity = 2,
        UserPrefCuisine = 101
    }
    public enum Enum_CategoryGroupStatus
    {
        Hide = ORFramework.Models.CodeTabeStatus.Hide,
        Normal = ORFramework.Models.CodeTabeStatus.Normal
    }

    public enum Enum_PopularDishStatus
    {
        Deactivate = 0,
        Active = 10
    }

    public enum Enum_PopularDishType
    {
        Restaurant = 1,
        Chain = 2,
    }


    public enum Enum_HomeBlockType
    {
        Grid = 1,
        Promotions = 2,
        ShowCase = 3,
        PoiSr1 = 4,
        PoiSr2 = 5,
        NearBy = 6,
        CouponSr1 = 7,
        CouponSr2 = 8,
        TopRestaurants = 9,
        NewRestaurants = 10,
        LeaderBoard = 11,
        Trending = 12,
        LatestReviews = 13,
        Topic = 14,
        Profile = 15,
        Settings = 16,
        Inbox = 17,
        Logon = 18,
        ReviewSubmit = 19,
        PhotoSubmit = 20,
        Intent = 21,
        Webview = 22,
        Browser = 23,
        OpenApp = 26,
       
        Carousel = 100,
        Carousel_BestRatedNearBy = 101,
        Carousel_TableAvailableNow = 102,
        Carousel_OfferNearBy = 103,
        Carousel_RecentEditorChoice = 104,
        Carousel_MostlyBookmarkedOffers = 105,
        HotPicks = 106,
        Magazine = 107,
        FeaturedCoupons = 108,
        FeatureRestaurants = 109,
        RestaurantsChart = 110,
        Listing = 111,
        TableMap =112,
        Location = 113,
        Cuisine = 114,
        Chat = 115,
        EditorsPick = 116,
        FeatureItem = 117,
        Carousel_Item = 118,
        Carousel_Slider = 119,
        EditorPickTopical = 120,
        TopDrawer = 121,
        MiddleDrawer = 122,
        Notification = 123,
        HomePage = 124,
        Separator =125,
        MyOR = 126,
        DraftReviews=127,
        Setting = 128,
        JobSr1 = 129,
        //-- v580
        WhatsNew = 130,
        RecommendedGroup = 131,
        DistrictGroup = 132,
        RecommendedPoi = 133,
        RecommendedOffer = 134, 
        Takeaway = 135,


        HomeFeatureItem = 1000,
        PromotionUI = 1001,
        BuffetUI = 1002,
        HotPotUI = 1003,
        PartyUI = 1004,
        LiveFootballUI = 1005,
        OnlineBookingUI = 1006,
        TableMapOffer = 1007,
        DeliveryOffer = 1008,
        Chart = 1009, // general chart with chart name
        DoubleClick = 1010,
        HtmlBlock = 1011,
        FeatureReview = 1012,
        Keyword = 1013,
        MobileCarousel = 1014,
        NavigationIcons = 1015,
        MobileNearBy = 1016,
        ChartUI = 1017,
        HomeChart = 1018, // chart for home page
        MobileLocation = 1019,
        MobileCuisine = 1020

    }
    public enum Enum_HomeBlockStatus
    {
        Active = 10,
        Inactive = 0
    }

    public enum Enum_HomePageType
    {
        AndroidLeftMenu = 1,
        IosBottomMenu = 2,
        AndroidHome = 3,
        IosHome = 4,
        AndroidHome_v5_8 = 5,
        IosHome_v5_8 = 6,
        WebHome = 101,
        WebRestaurantIndex = 102,
        MobileWebHome = 201,
        MobileWebRestaurantIndex = 202
    } 

    // Copy from API project: OpenRice.Models.DataTypes.Vendor.VendorId
    public enum Enum_VendorType
    {
        FoodPanda = 1,
        Queuing_Eat365 = 2, 
        Emenu_Eat365 = 3,
        Queuing_WebOn = 5,
        Takeaway_Eat365 = 7,
        Quandoo = 8,
        Emenu_Everyware = 9,
        DineIn_365 = 10,
        TakeyAway_Everyware = 11,
        DineIn_Everyware = 12,
        Emenu_Aigens = 13,
        TakeAway_Aigens = 14,
        DineIn_Aigens = 15,
        Emenu_Ucr = 16,
        TakeAway_Ucr = 17,
        DineIn_Ucr = 18,
        Emenu_AbleGenius = 19,
        TakeAway_AbleGenius = 20,
        DineIn_AbleGenius = 21,
        Emenu_Erun = 22,
        TakeAway_Erun = 23,
        DineIn_Erun = 24,
        Emenu_Mbs = 25,
        TakeAway_Mbs = 26,
        DineIn_Mbs = 27,
        Emenu_JoinWitt = 28,
        TakeAway_JoinWitt = 29,
        DineIn_JoinWitt = 30,
    }
    
    // Copy from API project: Biz.SharedService.Enum.Enum_BizServiceType
    public enum Enum_BizServiceType
    {
        TableMap = 1,
        Coupon = 2,
        ETicket = 3,
        TakeAway = 4,
        Voucher = 5,
        PayAtRestaurant = 6,
        RMSLite = 7,
        AsiaMiles = 8,
        CorpJob = 9,
        Emenu = 10,
        OnlinePayment = 11,

		Boost = 12,

        PayAtRestaurantWeChat= 15,
        OnlinePaymentWeChat = 16,
        PayAtRestaurantCreditCardVisa = 17,
        PayAtRestaurantCreditCardMastercard = 18,
        PayAtRestaurantCreditCardUnionPay = 19,
        PayAtRestaurantCreditCardAE = 20,
        PayAtRestaurantCreditCardJCB = 21,
        DineIn = 22,
        Landmark = 23,
        PayatRestaurantVisaMasterSelfKiosk = 24,
        ThirdPartyBookingService = 101,
    }

    // Copy from API project: OpenRice.Models.DataTypes.Event.EventStatus
    // Database column: Event.Status
    public enum Enum_EventStatus
    {
        Deleted = 0,
        Pending = 5,
        Confirmed = 10,
    }

    // Copy from API project: OpenRice.Models.DataTypes.Event.DecisionStatus
    // Database column: EventInvitee.Status
    public enum Enum_EventDecisionStatus
    {
        Yes = 1,
        No = 2,
        Maybe = 3,
    }
    public enum Enum_InboxNotificationMessageType
    {
        OfficialBroadcast = 1,
        ResturantPromotion = 2,
    }
    public enum Enum_InboxNotificationDeviceTypeId
    {
        All = 0,
        Android = 1,
        iOS = 2,
        MobileWeb = 3,
        DesktopWeb = 4,
    }
    public enum Enum_InboxNotificationDestinationType
    {
        Restaurant = 25,
        Coupon = 21,
        Article = 33,
        WebLink_InApp = 18,
        WebLink_OutApp = 19,
        CMS = 34,
    }
    public enum Enum_InboxNotificationStaus
    {
        Inactive = ArticleStatus.Inactive,
        Draft = ArticleStatus.Draft,
        Active = ArticleStatus.Active,
    }
    public enum Enum_SenderTypeId
    {
        OpenRiceLocal=1,
        OpenRiceEditor=2,
        OpenRiceCS=3,
        OpenRiceMarketing=4,
    }

    public enum Enum_ShareMessage_Status
    {
        Inactive = 0,
        Active = 10
    
    }

    public enum Enum_VendorOrderLogStatus
    {
        Fail = 0,
        Pending = 5,
        Success = 10
    }

    public enum Enum_BookmarkPoiSource
    {
        Unknown = 0, //-- Reserved
        Snap = 1, //-- Reserved
        User = 20, // app will pass this to API
        Auto = 30, // app will pass this to API (Screen Capture (iOS only) , Scan QR code to SR2, Buy Voucher, Create Booking)
        Auto_Review = 31, // API and ORBO save this to DB
        Auto_Coupon = 32, // API save this to DB
        Auto_Voucher = 33, // API save this to DB
        Auto_FoodPanda = 34
    }

    public enum Enum_ReviewVerifiedService
    {
        RedeemedVoucher = 1,
        OrderedDelivery = 2,
        ConfirmedBookingAttendance = 3
    }

    public enum Enum_ShortReviewType
    {
        Booking = 1,
        Voucher = 2,
        Delivery = 3,
        Takeaway = 4,
        SpotPayment = 5,
        DineIn = 6
    }

    public enum Enum_ShortReviewStatus
    {
        Inactive = 0,
        Active = 10
    }


    public enum Enum_ShortReviewImproveArea
    {
        Taste = 1,
        Service = 2,
        Decor = 3,
        Hygiene = 4,
        WaitTime = 5,
        Packaging = 6
    }

    public enum Enum_PoiPOSTypeId
    {
        Bettersoft              = 5  ,
        Bindo                   = 10 ,
        Cyberunc                = 15 ,   // Cyber Universal
        Eastop                  = 20 ,
        Eats365                 = 25 ,
        EBSPOS                  = 30 ,   // EBS
        eRUN                    = 35 ,
        Everyware               = 40 ,
        Gingersoft              = 45 ,
        HKDSL                   = 50 ,
        iChef                   = 55 ,
        Infrasys                = 60 ,
        Micro                   = 65 ,
        MITPOS                  = 70 ,   // Maxim IT POS
        Pointsoft               = 75 ,
        POSLink                 = 80 ,
        POSMaster               = 85 ,
        ProAn                   = 90 ,
        Profex                  = 95 ,
        Quicktime               = 100,
        Ravel                   = 105,
        Seito                   = 110,
        UCR                     = 115,
    }

    public enum Enum_PoiTMSTypeId
    {
        Chope                   = 5 ,
        Eat2Eat                 = 10,
        Infrasys                = 15,
        Inline                  = 20,
        Opentable_ResPAK        = 25,
        OptiTable               = 30,
        Quandoo                 = 35,
        ResDiary                = 40,
        Sevenrooms              = 45,
        WebOn                   = 50,
    }
}


