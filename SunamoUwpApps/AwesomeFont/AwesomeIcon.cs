namespace apps.AwesomeFont;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

    /// <summary>
    /// Represents the font awesome icon type.
    /// </summary>
    public enum FontAwesomeIcon
    {
        /// <summary>
        /// The none value.
        /// </summary>
        None = 0,
        /// <summary>
        /// The glass value.
        /// </summary>
        Glass = 0xf000,
        /// <summary>
        /// The music value.
        /// </summary>
        Music = 0xf001,
        /// <summary>
        /// The search value.
        /// </summary>
        Search = 0xf002,
        /// <summary>
        /// The envelope o value.
        /// </summary>
        EnvelopeO = 0xf003,
        /// <summary>
        /// The heart value.
        /// </summary>
        Heart = 0xf004,
        /// <summary>
        /// The star value.
        /// </summary>
        Star = 0xf005,
        /// <summary>
        /// The star o value.
        /// </summary>
        StarO = 0xf006,
        /// <summary>
        /// The user value.
        /// </summary>
        User = 0xf007,
        /// <summary>
        /// The film value.
        /// </summary>
        Film = 0xf008,
        /// <summary>
        /// The th large value.
        /// </summary>
        ThLarge = 0xf009,
        /// <summary>
        /// The th value.
        /// </summary>
        Th = 0xf00a,
        /// <summary>
        /// The th list value.
        /// </summary>
        ThList = 0xf00b,
        /// <summary>
        /// The check value.
        /// </summary>
        Check = 0xf00c,
        /// <summary>
        /// The times value.
        /// </summary>
        Times = 0xf00d,
        /// <summary>
        /// The search plus value.
        /// </summary>
        SearchPlus = 0xf00e,
        /// <summary>
        /// The search minus value.
        /// </summary>
        SearchMinus = 0xf010,
        /// <summary>
        /// The power off value.
        /// </summary>
        PowerOff = 0xf011,
        /// <summary>
        /// The signal value.
        /// </summary>
        Signal = 0xf012,
        /// <summary>
        /// The cog value.
        /// </summary>
        Cog = 0xf013,
        /// <summary>
        /// The trash o value.
        /// </summary>
        TrashO = 0xf014,
        /// <summary>
        /// The home value.
        /// </summary>
        Home = 0xf015,
        /// <summary>
        /// The file o value.
        /// </summary>
        FileO = 0xf016,
        /// <summary>
        /// The clock o value.
        /// </summary>
        ClockO = 0xf017,
        /// <summary>
        /// The road value.
        /// </summary>
        Road = 0xf018,
        /// <summary>
        /// The download value.
        /// </summary>
        Download = 0xf019,
        /// <summary>
        /// The arrow circle o down value.
        /// </summary>
        ArrowCircleODown = 0xf01a,
        /// <summary>
        /// The arrow circle o up value.
        /// </summary>
        ArrowCircleOUp = 0xf01b,
        /// <summary>
        /// The inbox value.
        /// </summary>
        Inbox = 0xf01c,
        /// <summary>
        /// The play circle o value.
        /// </summary>
        PlayCircleO = 0xf01d,
        /// <summary>
        /// The repeat value.
        /// </summary>
        Repeat = 0xf01e,
        /// <summary>
        /// The refresh value.
        /// </summary>
        Refresh = 0xf021,
        /// <summary>
        /// The list alt value.
        /// </summary>
        ListAlt = 0xf022,
        /// <summary>
        /// The lock value.
        /// </summary>
        Lock = 0xf023,
        /// <summary>
        /// The flag value.
        /// </summary>
        Flag = 0xf024,
        /// <summary>
        /// The headphones value.
        /// </summary>
        Headphones = 0xf025,
        /// <summary>
        /// The volume off value.
        /// </summary>
        VolumeOff = 0xf026,
        /// <summary>
        /// The volume down value.
        /// </summary>
        VolumeDown = 0xf027,
        /// <summary>
        /// The volume up value.
        /// </summary>
        VolumeUp = 0xf028,
        /// <summary>
        /// The qrcode value.
        /// </summary>
        Qrcode = 0xf029,
        /// <summary>
        /// The barcode value.
        /// </summary>
        Barcode = 0xf02a,
        /// <summary>
        /// The tag value.
        /// </summary>
        Tag = 0xf02b,
        /// <summary>
        /// The tags value.
        /// </summary>
        Tags = 0xf02c,
        /// <summary>
        /// The book value.
        /// </summary>
        Book = 0xf02d,
        /// <summary>
        /// The bookmark value.
        /// </summary>
        Bookmark = 0xf02e,
        /// <summary>
        /// The print value.
        /// </summary>
        Print = 0xf02f,
        /// <summary>
        /// The camera value.
        /// </summary>
        Camera = 0xf030,
        /// <summary>
        /// The font value.
        /// </summary>
        Font = 0xf031,
        /// <summary>
        /// The bold value.
        /// </summary>
        Bold = 0xf032,
        /// <summary>
        /// The italic value.
        /// </summary>
        Italic = 0xf033,
        /// <summary>
        /// The text height value.
        /// </summary>
        TextHeight = 0xf034,
        /// <summary>
        /// The text width value.
        /// </summary>
        TextWidth = 0xf035,
        /// <summary>
        /// The align left value.
        /// </summary>
        AlignLeft = 0xf036,
        /// <summary>
        /// The align center value.
        /// </summary>
        AlignCenter = 0xf037,
        /// <summary>
        /// The align right value.
        /// </summary>
        AlignRight = 0xf038,
        /// <summary>
        /// The align justify value.
        /// </summary>
        AlignJustify = 0xf039,
        /// <summary>
        /// The list value.
        /// </summary>
        List = 0xf03a,
        /// <summary>
        /// The outdent value.
        /// </summary>
        Outdent = 0xf03b,
        /// <summary>
        /// The indent value.
        /// </summary>
        Indent = 0xf03c,
        /// <summary>
        /// The video camera value.
        /// </summary>
        VideoCamera = 0xf03d,
        /// <summary>
        /// The picture o value.
        /// </summary>
        PictureO = 0xf03e,
        /// <summary>
        /// The pencil value.
        /// </summary>
        Pencil = 0xf040,
        /// <summary>
        /// The map marker value.
        /// </summary>
        MapMarker = 0xf041,
        /// <summary>
        /// The adjust value.
        /// </summary>
        Adjust = 0xf042,
        /// <summary>
        /// The tint value.
        /// </summary>
        Tint = 0xf043,
        /// <summary>
        /// The pencil square o value.
        /// </summary>
        PencilSquareO = 0xf044,
        /// <summary>
        /// The share square o value.
        /// </summary>
        ShareSquareO = 0xf045,
        /// <summary>
        /// The check square o value.
        /// </summary>
        CheckSquareO = 0xf046,
        /// <summary>
        /// The arrows value.
        /// </summary>
        Arrows = 0xf047,
        /// <summary>
        /// The step backward value.
        /// </summary>
        StepBackward = 0xf048,
        /// <summary>
        /// The fast backward value.
        /// </summary>
        FastBackward = 0xf049,
        /// <summary>
        /// The backward value.
        /// </summary>
        Backward = 0xf04a,
        /// <summary>
        /// The play value.
        /// </summary>
        Play = 0xf04b,
        /// <summary>
        /// The pause value.
        /// </summary>
        Pause = 0xf04c,
        /// <summary>
        /// The stop value.
        /// </summary>
        Stop = 0xf04d,
        /// <summary>
        /// The forward value.
        /// </summary>
        Forward = 0xf04e,
        /// <summary>
        /// The fast forward value.
        /// </summary>
        FastForward = 0xf050,
        /// <summary>
        /// The step forward value.
        /// </summary>
        StepForward = 0xf051,
        /// <summary>
        /// The eject value.
        /// </summary>
        Eject = 0xf052,
        /// <summary>
        /// The chevron left value.
        /// </summary>
        ChevronLeft = 0xf053,
        /// <summary>
        /// The chevron right value.
        /// </summary>
        ChevronRight = 0xf054,
        /// <summary>
        /// The plus circle value.
        /// </summary>
        PlusCircle = 0xf055,
        /// <summary>
        /// The minus circle value.
        /// </summary>
        MinusCircle = 0xf056,
        /// <summary>
        /// The times circle value.
        /// </summary>
        TimesCircle = 0xf057,
        /// <summary>
        /// The check circle value.
        /// </summary>
        CheckCircle = 0xf058,
        /// <summary>
        /// The question circle value.
        /// </summary>
        QuestionCircle = 0xf059,
        /// <summary>
        /// The info circle value.
        /// </summary>
        InfoCircle = 0xf05a,
        /// <summary>
        /// The crosshairs value.
        /// </summary>
        Crosshairs = 0xf05b,
        /// <summary>
        /// The times circle o value.
        /// </summary>
        TimesCircleO = 0xf05c,
        /// <summary>
        /// The check circle o value.
        /// </summary>
        CheckCircleO = 0xf05d,
        /// <summary>
        /// The ban value.
        /// </summary>
        Ban = 0xf05e,
        /// <summary>
        /// The arrow left value.
        /// </summary>
        ArrowLeft = 0xf060,
        /// <summary>
        /// The arrow right value.
        /// </summary>
        ArrowRight = 0xf061,
        /// <summary>
        /// The arrow up value.
        /// </summary>
        ArrowUp = 0xf062,
        /// <summary>
        /// The arrow down value.
        /// </summary>
        ArrowDown = 0xf063,
        /// <summary>
        /// The share value.
        /// </summary>
        Share = 0xf064,
        /// <summary>
        /// The expand value.
        /// </summary>
        Expand = 0xf065,
        /// <summary>
        /// The compress value.
        /// </summary>
        Compress = 0xf066,
        /// <summary>
        /// The plus value.
        /// </summary>
        Plus = 0xf067,
        /// <summary>
        /// The minus value.
        /// </summary>
        Minus = 0xf068,
        /// <summary>
        /// The asterisk value.
        /// </summary>
        Asterisk = 0xf069,
        /// <summary>
        /// The exclamation circle value.
        /// </summary>
        ExclamationCircle = 0xf06a,
        /// <summary>
        /// The gift value.
        /// </summary>
        Gift = 0xf06b,
        /// <summary>
        /// The leaf value.
        /// </summary>
        Leaf = 0xf06c,
        /// <summary>
        /// The fire value.
        /// </summary>
        Fire = 0xf06d,
        /// <summary>
        /// The eye value.
        /// </summary>
        Eye = 0xf06e,
        /// <summary>
        /// The eye slash value.
        /// </summary>
        EyeSlash = 0xf070,
        /// <summary>
        /// The exclamation triangle value.
        /// </summary>
        ExclamationTriangle = 0xf071,
        /// <summary>
        /// The plane value.
        /// </summary>
        Plane = 0xf072,
        /// <summary>
        /// The calendar value.
        /// </summary>
        Calendar = 0xf073,
        /// <summary>
        /// The random value.
        /// </summary>
        Random = 0xf074,
        /// <summary>
        /// The comment value.
        /// </summary>
        Comment = 0xf075,
        /// <summary>
        /// The magnet value.
        /// </summary>
        Magnet = 0xf076,
        /// <summary>
        /// The chevron up value.
        /// </summary>
        ChevronUp = 0xf077,
        /// <summary>
        /// The chevron down value.
        /// </summary>
        ChevronDown = 0xf078,
        /// <summary>
        /// The retweet value.
        /// </summary>
        Retweet = 0xf079,
        /// <summary>
        /// The shopping cart value.
        /// </summary>
        ShoppingCart = 0xf07a,
        /// <summary>
        /// The folder value.
        /// </summary>
        Folder = 0xf07b,
        /// <summary>
        /// The folder open value.
        /// </summary>
        FolderOpen = 0xf07c,
        /// <summary>
        /// The arrows v value.
        /// </summary>
        ArrowsV = 0xf07d,
        /// <summary>
        /// The arrows h value.
        /// </summary>
        ArrowsH = 0xf07e,
        /// <summary>
        /// The bar chart value.
        /// </summary>
        BarChart = 0xf080,
        /// <summary>
        /// The twitter square value.
        /// </summary>
        TwitterSquare = 0xf081,
        /// <summary>
        /// The facebook square value.
        /// </summary>
        FacebookSquare = 0xf082,
        /// <summary>
        /// The camera retro value.
        /// </summary>
        CameraRetro = 0xf083,
        /// <summary>
        /// The key value.
        /// </summary>
        Key = 0xf084,
        /// <summary>
        /// The cogs value.
        /// </summary>
        Cogs = 0xf085,
        /// <summary>
        /// The comments value.
        /// </summary>
        Comments = 0xf086,
        /// <summary>
        /// The thumbs o up value.
        /// </summary>
        ThumbsOUp = 0xf087,
        /// <summary>
        /// The thumbs o down value.
        /// </summary>
        ThumbsODown = 0xf088,
        /// <summary>
        /// The star half value.
        /// </summary>
        StarHalf = 0xf089,
        /// <summary>
        /// The heart o value.
        /// </summary>
        HeartO = 0xf08a,
        /// <summary>
        /// The sign out value.
        /// </summary>
        SignOut = 0xf08b,
        /// <summary>
        /// The linkedin square value.
        /// </summary>
        LinkedinSquare = 0xf08c,
        /// <summary>
        /// The thumb tack value.
        /// </summary>
        ThumbTack = 0xf08d,
        /// <summary>
        /// The external link value.
        /// </summary>
        ExternalLink = 0xf08e,
        /// <summary>
        /// The sign in value.
        /// </summary>
        SignIn = 0xf090,
        /// <summary>
        /// The trophy value.
        /// </summary>
        Trophy = 0xf091,
        /// <summary>
        /// The github square value.
        /// </summary>
        GithubSquare = 0xf092,
        /// <summary>
        /// The upload value.
        /// </summary>
        Upload = 0xf093,
        /// <summary>
        /// The lemon o value.
        /// </summary>
        LemonO = 0xf094,
        /// <summary>
        /// The phone value.
        /// </summary>
        Phone = 0xf095,
        /// <summary>
        /// The square o value.
        /// </summary>
        SquareO = 0xf096,
        /// <summary>
        /// The bookmark o value.
        /// </summary>
        BookmarkO = 0xf097,
        /// <summary>
        /// The phone square value.
        /// </summary>
        PhoneSquare = 0xf098,
        /// <summary>
        /// The twitter value.
        /// </summary>
        Twitter = 0xf099,
        /// <summary>
        /// The facebook value.
        /// </summary>
        Facebook = 0xf09a,
        /// <summary>
        /// The github value.
        /// </summary>
        Github = 0xf09b,
        /// <summary>
        /// The unlock value.
        /// </summary>
        Unlock = 0xf09c,
        /// <summary>
        /// The credit card value.
        /// </summary>
        CreditCard = 0xf09d,
        /// <summary>
        /// The rss value.
        /// </summary>
        Rss = 0xf09e,
        /// <summary>
        /// The hdd o value.
        /// </summary>
        HddO = 0xf0a0,
        /// <summary>
        /// The bullhorn value.
        /// </summary>
        Bullhorn = 0xf0a1,
        /// <summary>
        /// The bell value.
        /// </summary>
        Bell = 0xf0f3,
        /// <summary>
        /// The certificate value.
        /// </summary>
        Certificate = 0xf0a3,
        /// <summary>
        /// The hand o right value.
        /// </summary>
        HandORight = 0xf0a4,
        /// <summary>
        /// The hand o left value.
        /// </summary>
        HandOLeft = 0xf0a5,
        /// <summary>
        /// The hand o up value.
        /// </summary>
        HandOUp = 0xf0a6,
        /// <summary>
        /// The hand o down value.
        /// </summary>
        HandODown = 0xf0a7,
        /// <summary>
        /// The arrow circle left value.
        /// </summary>
        ArrowCircleLeft = 0xf0a8,
        /// <summary>
        /// The arrow circle right value.
        /// </summary>
        ArrowCircleRight = 0xf0a9,
        /// <summary>
        /// The arrow circle up value.
        /// </summary>
        ArrowCircleUp = 0xf0aa,
        /// <summary>
        /// The arrow circle down value.
        /// </summary>
        ArrowCircleDown = 0xf0ab,
        /// <summary>
        /// The globe value.
        /// </summary>
        Globe = 0xf0ac,
        /// <summary>
        /// The wrench value.
        /// </summary>
        Wrench = 0xf0ad,
        /// <summary>
        /// The tasks value.
        /// </summary>
        Tasks = 0xf0ae,
        /// <summary>
        /// The filter value.
        /// </summary>
        Filter = 0xf0b0,
        /// <summary>
        /// The briefcase value.
        /// </summary>
        Briefcase = 0xf0b1,
        /// <summary>
        /// The arrows alt value.
        /// </summary>
        ArrowsAlt = 0xf0b2,
        /// <summary>
        /// The users value.
        /// </summary>
        Users = 0xf0c0,
        /// <summary>
        /// The link value.
        /// </summary>
        Link = 0xf0c1,
        /// <summary>
        /// The cloud value.
        /// </summary>
        Cloud = 0xf0c2,
        /// <summary>
        /// The flask value.
        /// </summary>
        Flask = 0xf0c3,
        /// <summary>
        /// The scissors value.
        /// </summary>
        Scissors = 0xf0c4,
        /// <summary>
        /// The files o value.
        /// </summary>
        FilesO = 0xf0c5,
        /// <summary>
        /// The paperclip value.
        /// </summary>
        Paperclip = 0xf0c6,
        /// <summary>
        /// The floppy o value.
        /// </summary>
        FloppyO = 0xf0c7,
        /// <summary>
        /// The square value.
        /// </summary>
        Square = 0xf0c8,
        /// <summary>
        /// The bars value.
        /// </summary>
        Bars = 0xf0c9,
        /// <summary>
        /// The list ul value.
        /// </summary>
        ListUl = 0xf0ca,
        /// <summary>
        /// The list ol value.
        /// </summary>
        ListOl = 0xf0cb,
        /// <summary>
        /// The strikethrough value.
        /// </summary>
        Strikethrough = 0xf0cc,
        /// <summary>
        /// The underline value.
        /// </summary>
        Underline = 0xf0cd,
        /// <summary>
        /// The table value.
        /// </summary>
        Table = 0xf0ce,
        /// <summary>
        /// The magic value.
        /// </summary>
        Magic = 0xf0d0,
        /// <summary>
        /// The truck value.
        /// </summary>
        Truck = 0xf0d1,
        /// <summary>
        /// The pinterest value.
        /// </summary>
        Pinterest = 0xf0d2,
        /// <summary>
        /// The pinterest square value.
        /// </summary>
        PinterestSquare = 0xf0d3,
        /// <summary>
        /// The google plus square value.
        /// </summary>
        GooglePlusSquare = 0xf0d4,
        /// <summary>
        /// The google plus value.
        /// </summary>
        GooglePlus = 0xf0d5,
        /// <summary>
        /// The money value.
        /// </summary>
        Money = 0xf0d6,
        /// <summary>
        /// The caret down value.
        /// </summary>
        CaretDown = 0xf0d7,
        /// <summary>
        /// The caret up value.
        /// </summary>
        CaretUp = 0xf0d8,
        /// <summary>
        /// The caret left value.
        /// </summary>
        CaretLeft = 0xf0d9,
        /// <summary>
        /// The caret right value.
        /// </summary>
        CaretRight = 0xf0da,
        /// <summary>
        /// The columns value.
        /// </summary>
        Columns = 0xf0db,
        /// <summary>
        /// The sort value.
        /// </summary>
        Sort = 0xf0dc,
        /// <summary>
        /// The sort desc value.
        /// </summary>
        SortDesc = 0xf0dd,
        /// <summary>
        /// The sort asc value.
        /// </summary>
        SortAsc = 0xf0de,
        /// <summary>
        /// The envelope value.
        /// </summary>
        Envelope = 0xf0e0,
        /// <summary>
        /// The linkedin value.
        /// </summary>
        Linkedin = 0xf0e1,
        /// <summary>
        /// The undo value.
        /// </summary>
        Undo = 0xf0e2,
        /// <summary>
        /// The gavel value.
        /// </summary>
        Gavel = 0xf0e3,
        /// <summary>
        /// The tachometer value.
        /// </summary>
        Tachometer = 0xf0e4,
        /// <summary>
        /// The comment o value.
        /// </summary>
        CommentO = 0xf0e5,
        /// <summary>
        /// The comments o value.
        /// </summary>
        CommentsO = 0xf0e6,
        /// <summary>
        /// The bolt value.
        /// </summary>
        Bolt = 0xf0e7,
        /// <summary>
        /// The sitemap value.
        /// </summary>
        Sitemap = 0xf0e8,
        /// <summary>
        /// The umbrella value.
        /// </summary>
        Umbrella = 0xf0e9,
        /// <summary>
        /// The clipboard value.
        /// </summary>
        Clipboard = 0xf0ea,
        /// <summary>
        /// The lightbulb o value.
        /// </summary>
        LightbulbO = 0xf0eb,
        /// <summary>
        /// The exchange value.
        /// </summary>
        Exchange = 0xf0ec,
        /// <summary>
        /// The cloud download value.
        /// </summary>
        CloudDownload = 0xf0ed,
        /// <summary>
        /// The cloud upload value.
        /// </summary>
        CloudUpload = 0xf0ee,
        /// <summary>
        /// The user md value.
        /// </summary>
        UserMd = 0xf0f0,
        /// <summary>
        /// The stethoscope value.
        /// </summary>
        Stethoscope = 0xf0f1,
        /// <summary>
        /// The suitcase value.
        /// </summary>
        Suitcase = 0xf0f2,
        /// <summary>
        /// The bell o value.
        /// </summary>
        BellO = 0xf0a2,
        /// <summary>
        /// The coffee value.
        /// </summary>
        Coffee = 0xf0f4,
        /// <summary>
        /// The cutlery value.
        /// </summary>
        Cutlery = 0xf0f5,
        /// <summary>
        /// The file text o value.
        /// </summary>
        FileTextO = 0xf0f6,
        /// <summary>
        /// The building o value.
        /// </summary>
        BuildingO = 0xf0f7,
        /// <summary>
        /// The hospital o value.
        /// </summary>
        HospitalO = 0xf0f8,
        /// <summary>
        /// The ambulance value.
        /// </summary>
        Ambulance = 0xf0f9,
        /// <summary>
        /// The medkit value.
        /// </summary>
        Medkit = 0xf0fa,
        /// <summary>
        /// The fighter jet value.
        /// </summary>
        FighterJet = 0xf0fb,
        /// <summary>
        /// The beer value.
        /// </summary>
        Beer = 0xf0fc,
        /// <summary>
        /// The h square value.
        /// </summary>
        HSquare = 0xf0fd,
        /// <summary>
        /// The plus square value.
        /// </summary>
        PlusSquare = 0xf0fe,
        /// <summary>
        /// The angle double left value.
        /// </summary>
        AngleDoubleLeft = 0xf100,
        /// <summary>
        /// The angle double right value.
        /// </summary>
        AngleDoubleRight = 0xf101,
        /// <summary>
        /// The angle double up value.
        /// </summary>
        AngleDoubleUp = 0xf102,
        /// <summary>
        /// The angle double down value.
        /// </summary>
        AngleDoubleDown = 0xf103,
        /// <summary>
        /// The angle left value.
        /// </summary>
        AngleLeft = 0xf104,
        /// <summary>
        /// The angle right value.
        /// </summary>
        AngleRight = 0xf105,
        /// <summary>
        /// The angle up value.
        /// </summary>
        AngleUp = 0xf106,
        /// <summary>
        /// The angle down value.
        /// </summary>
        AngleDown = 0xf107,
        /// <summary>
        /// The desktop value.
        /// </summary>
        Desktop = 0xf108,
        /// <summary>
        /// The laptop value.
        /// </summary>
        Laptop = 0xf109,
        /// <summary>
        /// The tablet value.
        /// </summary>
        Tablet = 0xf10a,
        /// <summary>
        /// The mobile value.
        /// </summary>
        Mobile = 0xf10b,
        /// <summary>
        /// The circle o value.
        /// </summary>
        CircleO = 0xf10c,
        /// <summary>
        /// The quote left value.
        /// </summary>
        QuoteLeft = 0xf10d,
        /// <summary>
        /// The quote right value.
        /// </summary>
        QuoteRight = 0xf10e,
        /// <summary>
        /// The spinner value.
        /// </summary>
        Spinner = 0xf110,
        /// <summary>
        /// The circle value.
        /// </summary>
        Circle = 0xf111,
        /// <summary>
        /// The reply value.
        /// </summary>
        Reply = 0xf112,
        /// <summary>
        /// The github alt value.
        /// </summary>
        GithubAlt = 0xf113,
        /// <summary>
        /// The folder o value.
        /// </summary>
        FolderO = 0xf114,
        /// <summary>
        /// The folder open o value.
        /// </summary>
        FolderOpenO = 0xf115,
        /// <summary>
        /// The smile o value.
        /// </summary>
        SmileO = 0xf118,
        /// <summary>
        /// The frown o value.
        /// </summary>
        FrownO = 0xf119,
        /// <summary>
        /// The meh o value.
        /// </summary>
        MehO = 0xf11a,
        /// <summary>
        /// The gamepad value.
        /// </summary>
        Gamepad = 0xf11b,
        /// <summary>
        /// The keyboard o value.
        /// </summary>
        KeyboardO = 0xf11c,
        /// <summary>
        /// The flag o value.
        /// </summary>
        FlagO = 0xf11d,
        /// <summary>
        /// The flag checkered value.
        /// </summary>
        FlagCheckered = 0xf11e,
        /// <summary>
        /// The terminal value.
        /// </summary>
        Terminal = 0xf120,
        /// <summary>
        /// The code value.
        /// </summary>
        Code = 0xf121,
        /// <summary>
        /// The reply all value.
        /// </summary>
        ReplyAll = 0xf122,
        /// <summary>
        /// The star half o value.
        /// </summary>
        StarHalfO = 0xf123,
        /// <summary>
        /// The location arrow value.
        /// </summary>
        LocationArrow = 0xf124,
        /// <summary>
        /// The crop value.
        /// </summary>
        Crop = 0xf125,
        /// <summary>
        /// The code fork value.
        /// </summary>
        CodeFork = 0xf126,
        /// <summary>
        /// The chain broken value.
        /// </summary>
        ChainBroken = 0xf127,
        /// <summary>
        /// The question value.
        /// </summary>
        Question = 0xf128,
        /// <summary>
        /// The info value.
        /// </summary>
        Info = 0xf129,
        /// <summary>
        /// The exclamation value.
        /// </summary>
        Exclamation = 0xf12a,
        /// <summary>
        /// The superscript value.
        /// </summary>
        Superscript = 0xf12b,
        /// <summary>
        /// The subscript value.
        /// </summary>
        Subscript = 0xf12c,
        /// <summary>
        /// The eraser value.
        /// </summary>
        Eraser = 0xf12d,
        /// <summary>
        /// The puzzle piece value.
        /// </summary>
        PuzzlePiece = 0xf12e,
        /// <summary>
        /// The microphone value.
        /// </summary>
        Microphone = 0xf130,
        /// <summary>
        /// The microphone slash value.
        /// </summary>
        MicrophoneSlash = 0xf131,
        /// <summary>
        /// The shield value.
        /// </summary>
        Shield = 0xf132,
        /// <summary>
        /// The calendar o value.
        /// </summary>
        CalendarO = 0xf133,
        /// <summary>
        /// The fire extinguisher value.
        /// </summary>
        FireExtinguisher = 0xf134,
        /// <summary>
        /// The rocket value.
        /// </summary>
        Rocket = 0xf135,
        /// <summary>
        /// The maxcdn value.
        /// </summary>
        Maxcdn = 0xf136,
        /// <summary>
        /// The chevron circle left value.
        /// </summary>
        ChevronCircleLeft = 0xf137,
        /// <summary>
        /// The chevron circle right value.
        /// </summary>
        ChevronCircleRight = 0xf138,
        /// <summary>
        /// The chevron circle up value.
        /// </summary>
        ChevronCircleUp = 0xf139,
        /// <summary>
        /// The chevron circle down value.
        /// </summary>
        ChevronCircleDown = 0xf13a,
        /// <summary>
        /// The html 5 value.
        /// </summary>
        Html5 = 0xf13b,
        /// <summary>
        /// The css 3 value.
        /// </summary>
        Css3 = 0xf13c,
        /// <summary>
        /// The anchor value.
        /// </summary>
        Anchor = 0xf13d,
        /// <summary>
        /// The unlock alt value.
        /// </summary>
        UnlockAlt = 0xf13e,
        /// <summary>
        /// The bullseye value.
        /// </summary>
        Bullseye = 0xf140,
        /// <summary>
        /// The ellipsis h value.
        /// </summary>
        EllipsisH = 0xf141,
        /// <summary>
        /// The ellipsis v value.
        /// </summary>
        EllipsisV = 0xf142,
        /// <summary>
        /// The rss square value.
        /// </summary>
        RssSquare = 0xf143,
        /// <summary>
        /// The play circle value.
        /// </summary>
        PlayCircle = 0xf144,
        /// <summary>
        /// The ticket value.
        /// </summary>
        Ticket = 0xf145,
        /// <summary>
        /// The minus square value.
        /// </summary>
        MinusSquare = 0xf146,
        /// <summary>
        /// The minus square o value.
        /// </summary>
        MinusSquareO = 0xf147,
        /// <summary>
        /// The level up value.
        /// </summary>
        LevelUp = 0xf148,
        /// <summary>
        /// The level down value.
        /// </summary>
        LevelDown = 0xf149,
        /// <summary>
        /// The check square value.
        /// </summary>
        CheckSquare = 0xf14a,
        /// <summary>
        /// The pencil square value.
        /// </summary>
        PencilSquare = 0xf14b,
        /// <summary>
        /// The external link square value.
        /// </summary>
        ExternalLinkSquare = 0xf14c,
        /// <summary>
        /// The share square value.
        /// </summary>
        ShareSquare = 0xf14d,
        /// <summary>
        /// The compass value.
        /// </summary>
        Compass = 0xf14e,
        /// <summary>
        /// The caret square o down value.
        /// </summary>
        CaretSquareODown = 0xf150,
        /// <summary>
        /// The caret square o up value.
        /// </summary>
        CaretSquareOUp = 0xf151,
        /// <summary>
        /// The caret square o right value.
        /// </summary>
        CaretSquareORight = 0xf152,
        /// <summary>
        /// The eur value.
        /// </summary>
        Eur = 0xf153,
        /// <summary>
        /// The gbp value.
        /// </summary>
        Gbp = 0xf154,
        /// <summary>
        /// The usd value.
        /// </summary>
        Usd = 0xf155,
        /// <summary>
        /// The inr value.
        /// </summary>
        Inr = 0xf156,
        /// <summary>
        /// The jpy value.
        /// </summary>
        Jpy = 0xf157,
        /// <summary>
        /// The rub value.
        /// </summary>
        Rub = 0xf158,
        /// <summary>
        /// The krw value.
        /// </summary>
        Krw = 0xf159,
        /// <summary>
        /// The btc value.
        /// </summary>
        Btc = 0xf15a,
        /// <summary>
        /// The file value.
        /// </summary>
        File = 0xf15b,
        /// <summary>
        /// The file text value.
        /// </summary>
        FileText = 0xf15c,
        /// <summary>
        /// The sort alpha asc value.
        /// </summary>
        SortAlphaAsc = 0xf15d,
        /// <summary>
        /// The sort alpha desc value.
        /// </summary>
        SortAlphaDesc = 0xf15e,
        /// <summary>
        /// The sort amount asc value.
        /// </summary>
        SortAmountAsc = 0xf160,
        /// <summary>
        /// The sort amount desc value.
        /// </summary>
        SortAmountDesc = 0xf161,
        /// <summary>
        /// The sort numeric asc value.
        /// </summary>
        SortNumericAsc = 0xf162,
        /// <summary>
        /// The sort numeric desc value.
        /// </summary>
        SortNumericDesc = 0xf163,
        /// <summary>
        /// The thumbs up value.
        /// </summary>
        ThumbsUp = 0xf164,
        /// <summary>
        /// The thumbs down value.
        /// </summary>
        ThumbsDown = 0xf165,
        /// <summary>
        /// The youtube square value.
        /// </summary>
        YoutubeSquare = 0xf166,
        /// <summary>
        /// The youtube value.
        /// </summary>
        Youtube = 0xf167,
        /// <summary>
        /// The xing value.
        /// </summary>
        Xing = 0xf168,
        /// <summary>
        /// The xing square value.
        /// </summary>
        XingSquare = 0xf169,
        /// <summary>
        /// The youtube play value.
        /// </summary>
        YoutubePlay = 0xf16a,
        /// <summary>
        /// The dropbox value.
        /// </summary>
        Dropbox = 0xf16b,
        /// <summary>
        /// The stack overflow value.
        /// </summary>
        StackOverflow = 0xf16c,
        /// <summary>
        /// The instagram value.
        /// </summary>
        Instagram = 0xf16d,
        /// <summary>
        /// The flickr value.
        /// </summary>
        Flickr = 0xf16e,
        /// <summary>
        /// The adn value.
        /// </summary>
        Adn = 0xf170,
        /// <summary>
        /// The bitbucket value.
        /// </summary>
        Bitbucket = 0xf171,
        /// <summary>
        /// The bitbucket square value.
        /// </summary>
        BitbucketSquare = 0xf172,
        /// <summary>
        /// The tumblr value.
        /// </summary>
        Tumblr = 0xf173,
        /// <summary>
        /// The tumblr square value.
        /// </summary>
        TumblrSquare = 0xf174,
        /// <summary>
        /// The long arrow down value.
        /// </summary>
        LongArrowDown = 0xf175,
        /// <summary>
        /// The long arrow up value.
        /// </summary>
        LongArrowUp = 0xf176,
        /// <summary>
        /// The long arrow left value.
        /// </summary>
        LongArrowLeft = 0xf177,
        /// <summary>
        /// The long arrow right value.
        /// </summary>
        LongArrowRight = 0xf178,
        /// <summary>
        /// The apple value.
        /// </summary>
        Apple = 0xf179,
        /// <summary>
        /// The windows value.
        /// </summary>
        Windows = 0xf17a,
        /// <summary>
        /// The android value.
        /// </summary>
        Android = 0xf17b,
        /// <summary>
        /// The linux value.
        /// </summary>
        Linux = 0xf17c,
        /// <summary>
        /// The dribbble value.
        /// </summary>
        Dribbble = 0xf17d,
        /// <summary>
        /// The skype value.
        /// </summary>
        Skype = 0xf17e,
        /// <summary>
        /// The foursquare value.
        /// </summary>
        Foursquare = 0xf180,
        /// <summary>
        /// The trello value.
        /// </summary>
        Trello = 0xf181,
        /// <summary>
        /// The female value.
        /// </summary>
        Female = 0xf182,
        /// <summary>
        /// The male value.
        /// </summary>
        Male = 0xf183,
        /// <summary>
        /// The gittip value.
        /// </summary>
        Gittip = 0xf184,
        /// <summary>
        /// The sun o value.
        /// </summary>
        SunO = 0xf185,
        /// <summary>
        /// The moon o value.
        /// </summary>
        MoonO = 0xf186,
        /// <summary>
        /// The archive value.
        /// </summary>
        Archive = 0xf187,
        /// <summary>
        /// The bug value.
        /// </summary>
        Bug = 0xf188,
        /// <summary>
        /// The vk value.
        /// </summary>
        Vk = 0xf189,
        /// <summary>
        /// The weibo value.
        /// </summary>
        Weibo = 0xf18a,
        /// <summary>
        /// The renren value.
        /// </summary>
        Renren = 0xf18b,
        /// <summary>
        /// The pagelines value.
        /// </summary>
        Pagelines = 0xf18c,
        /// <summary>
        /// The stack exchange value.
        /// </summary>
        StackExchange = 0xf18d,
        /// <summary>
        /// The arrow circle o right value.
        /// </summary>
        ArrowCircleORight = 0xf18e,
        /// <summary>
        /// The arrow circle o left value.
        /// </summary>
        ArrowCircleOLeft = 0xf190,
        /// <summary>
        /// The caret square o left value.
        /// </summary>
        CaretSquareOLeft = 0xf191,
        /// <summary>
        /// The dot circle o value.
        /// </summary>
        DotCircleO = 0xf192,
        /// <summary>
        /// The wheelchair value.
        /// </summary>
        Wheelchair = 0xf193,
        /// <summary>
        /// The vimeo square value.
        /// </summary>
        VimeoSquare = 0xf194,
        /// <summary>
        /// The try value.
        /// </summary>
        Try = 0xf195,
        /// <summary>
        /// The plus square o value.
        /// </summary>
        PlusSquareO = 0xf196,
        /// <summary>
        /// The space shuttle value.
        /// </summary>
        SpaceShuttle = 0xf197,
        /// <summary>
        /// The slack value.
        /// </summary>
        Slack = 0xf198,
        /// <summary>
        /// The envelope square value.
        /// </summary>
        EnvelopeSquare = 0xf199,
        /// <summary>
        /// The wordpress value.
        /// </summary>
        Wordpress = 0xf19a,
        /// <summary>
        /// The openid value.
        /// </summary>
        Openid = 0xf19b,
        /// <summary>
        /// The university value.
        /// </summary>
        University = 0xf19c,
        /// <summary>
        /// The graduation cap value.
        /// </summary>
        GraduationCap = 0xf19d,
        /// <summary>
        /// The yahoo value.
        /// </summary>
        Yahoo = 0xf19e,
        /// <summary>
        /// The google value.
        /// </summary>
        Google = 0xf1a0,
        /// <summary>
        /// The reddit value.
        /// </summary>
        Reddit = 0xf1a1,
        /// <summary>
        /// The reddit square value.
        /// </summary>
        RedditSquare = 0xf1a2,
        /// <summary>
        /// The stumbleupon circle value.
        /// </summary>
        StumbleuponCircle = 0xf1a3,
        /// <summary>
        /// The stumbleupon value.
        /// </summary>
        Stumbleupon = 0xf1a4,
        /// <summary>
        /// The delicious value.
        /// </summary>
        Delicious = 0xf1a5,
        /// <summary>
        /// The digg value.
        /// </summary>
        Digg = 0xf1a6,
        /// <summary>
        /// The pied piper value.
        /// </summary>
        PiedPiper = 0xf1a7,
        /// <summary>
        /// The pied piper alt value.
        /// </summary>
        PiedPiperAlt = 0xf1a8,
        /// <summary>
        /// The drupal value.
        /// </summary>
        Drupal = 0xf1a9,
        /// <summary>
        /// The joomla value.
        /// </summary>
        Joomla = 0xf1aa,
        /// <summary>
        /// The language value.
        /// </summary>
        Language = 0xf1ab,
        /// <summary>
        /// The fax value.
        /// </summary>
        Fax = 0xf1ac,
        /// <summary>
        /// The building value.
        /// </summary>
        Building = 0xf1ad,
        /// <summary>
        /// The child value.
        /// </summary>
        Child = 0xf1ae,
        /// <summary>
        /// The paw value.
        /// </summary>
        Paw = 0xf1b0,
        /// <summary>
        /// The spoon value.
        /// </summary>
        Spoon = 0xf1b1,
        /// <summary>
        /// The cube value.
        /// </summary>
        Cube = 0xf1b2,
        /// <summary>
        /// The cubes value.
        /// </summary>
        Cubes = 0xf1b3,
        /// <summary>
        /// The behance value.
        /// </summary>
        Behance = 0xf1b4,
        /// <summary>
        /// The behance square value.
        /// </summary>
        BehanceSquare = 0xf1b5,
        /// <summary>
        /// The steam value.
        /// </summary>
        Steam = 0xf1b6,
        /// <summary>
        /// The steam square value.
        /// </summary>
        SteamSquare = 0xf1b7,
        /// <summary>
        /// The recycle value.
        /// </summary>
        Recycle = 0xf1b8,
        /// <summary>
        /// The car value.
        /// </summary>
        Car = 0xf1b9,
        /// <summary>
        /// The taxi value.
        /// </summary>
        Taxi = 0xf1ba,
        /// <summary>
        /// The tree value.
        /// </summary>
        Tree = 0xf1bb,
        /// <summary>
        /// The spotify value.
        /// </summary>
        Spotify = 0xf1bc,
        /// <summary>
        /// The deviantart value.
        /// </summary>
        Deviantart = 0xf1bd,
        /// <summary>
        /// The soundcloud value.
        /// </summary>
        Soundcloud = 0xf1be,
        /// <summary>
        /// The database value.
        /// </summary>
        Database = 0xf1c0,
        /// <summary>
        /// The file pdf o value.
        /// </summary>
        FilePdfO = 0xf1c1,
        /// <summary>
        /// The file word o value.
        /// </summary>
        FileWordO = 0xf1c2,
        /// <summary>
        /// The file excel o value.
        /// </summary>
        FileExcelO = 0xf1c3,
        /// <summary>
        /// The file powerpoint o value.
        /// </summary>
        FilePowerpointO = 0xf1c4,
        /// <summary>
        /// The file image o value.
        /// </summary>
        FileImageO = 0xf1c5,
        /// <summary>
        /// The file archive o value.
        /// </summary>
        FileArchiveO = 0xf1c6,
        /// <summary>
        /// The file audio o value.
        /// </summary>
        FileAudioO = 0xf1c7,
        /// <summary>
        /// The file video o value.
        /// </summary>
        FileVideoO = 0xf1c8,
        /// <summary>
        /// The file code o value.
        /// </summary>
        FileCodeO = 0xf1c9,
        /// <summary>
        /// The vine value.
        /// </summary>
        Vine = 0xf1ca,
        /// <summary>
        /// The codepen value.
        /// </summary>
        Codepen = 0xf1cb,
        /// <summary>
        /// The jsfiddle value.
        /// </summary>
        Jsfiddle = 0xf1cc,
        /// <summary>
        /// The life ring value.
        /// </summary>
        LifeRing = 0xf1cd,
        /// <summary>
        /// The circle o notch value.
        /// </summary>
        CircleONotch = 0xf1ce,
        /// <summary>
        /// The rebel value.
        /// </summary>
        Rebel = 0xf1d0,
        /// <summary>
        /// The empire value.
        /// </summary>
        Empire = 0xf1d1,
        /// <summary>
        /// The git square value.
        /// </summary>
        GitSquare = 0xf1d2,
        /// <summary>
        /// The git value.
        /// </summary>
        Git = 0xf1d3,
        /// <summary>
        /// The hacker news value.
        /// </summary>
        HackerNews = 0xf1d4,
        /// <summary>
        /// The tencent weibo value.
        /// </summary>
        TencentWeibo = 0xf1d5,
        /// <summary>
        /// The qq value.
        /// </summary>
        Qq = 0xf1d6,
        /// <summary>
        /// The weixin value.
        /// </summary>
        Weixin = 0xf1d7,
        /// <summary>
        /// The paper plane value.
        /// </summary>
        PaperPlane = 0xf1d8,
        /// <summary>
        /// The paper plane o value.
        /// </summary>
        PaperPlaneO = 0xf1d9,
        /// <summary>
        /// The history value.
        /// </summary>
        History = 0xf1da,
        /// <summary>
        /// The circle thin value.
        /// </summary>
        CircleThin = 0xf1db,
        /// <summary>
        /// The header value.
        /// </summary>
        Header = 0xf1dc,
        /// <summary>
        /// The paragraph value.
        /// </summary>
        Paragraph = 0xf1dd,
        /// <summary>
        /// The sliders value.
        /// </summary>
        Sliders = 0xf1de,
        /// <summary>
        /// The share alt value.
        /// </summary>
        ShareAlt = 0xf1e0,
        /// <summary>
        /// The share alt square value.
        /// </summary>
        ShareAltSquare = 0xf1e1,
        /// <summary>
        /// The bomb value.
        /// </summary>
        Bomb = 0xf1e2,
        /// <summary>
        /// The futbol o value.
        /// </summary>
        FutbolO = 0xf1e3,
        /// <summary>
        /// The tty value.
        /// </summary>
        Tty = 0xf1e4,
        /// <summary>
        /// The binoculars value.
        /// </summary>
        Binoculars = 0xf1e5,
        /// <summary>
        /// The plug value.
        /// </summary>
        Plug = 0xf1e6,
        /// <summary>
        /// The slideshare value.
        /// </summary>
        Slideshare = 0xf1e7,
        /// <summary>
        /// The twitch value.
        /// </summary>
        Twitch = 0xf1e8,
        /// <summary>
        /// The yelp value.
        /// </summary>
        Yelp = 0xf1e9,
        /// <summary>
        /// The newspaper o value.
        /// </summary>
        NewspaperO = 0xf1ea,
        /// <summary>
        /// The wifi value.
        /// </summary>
        Wifi = 0xf1eb,
        /// <summary>
        /// The calculator value.
        /// </summary>
        Calculator = 0xf1ec,
        /// <summary>
        /// The paypal value.
        /// </summary>
        Paypal = 0xf1ed,
        /// <summary>
        /// The google wallet value.
        /// </summary>
        GoogleWallet = 0xf1ee,
        /// <summary>
        /// The cc visa value.
        /// </summary>
        CcVisa = 0xf1f0,
        /// <summary>
        /// The cc mastercard value.
        /// </summary>
        CcMastercard = 0xf1f1,
        /// <summary>
        /// The cc discover value.
        /// </summary>
        CcDiscover = 0xf1f2,
        /// <summary>
        /// The cc amex value.
        /// </summary>
        CcAmex = 0xf1f3,
        /// <summary>
        /// The cc paypal value.
        /// </summary>
        CcPaypal = 0xf1f4,
        /// <summary>
        /// The cc stripe value.
        /// </summary>
        CcStripe = 0xf1f5,
        /// <summary>
        /// The bell slash value.
        /// </summary>
        BellSlash = 0xf1f6,
        /// <summary>
        /// The bell slash o value.
        /// </summary>
        BellSlashO = 0xf1f7,
        /// <summary>
        /// The trash value.
        /// </summary>
        Trash = 0xf1f8,
        /// <summary>
        /// The copyright value.
        /// </summary>
        Copyright = 0xf1f9,
        /// <summary>
        /// The at value.
        /// </summary>
        At = 0xf1fa,
        /// <summary>
        /// The eyedropper value.
        /// </summary>
        Eyedropper = 0xf1fb,
        /// <summary>
        /// The paint brush value.
        /// </summary>
        PaintBrush = 0xf1fc,
        /// <summary>
        /// The birthday cake value.
        /// </summary>
        BirthdayCake = 0xf1fd,
        /// <summary>
        /// The area chart value.
        /// </summary>
        AreaChart = 0xf1fe,
        /// <summary>
        /// The pie chart value.
        /// </summary>
        PieChart = 0xf200,
        /// <summary>
        /// The line chart value.
        /// </summary>
        LineChart = 0xf201,
        /// <summary>
        /// The lastfm value.
        /// </summary>
        Lastfm = 0xf202,
        /// <summary>
        /// The lastfm square value.
        /// </summary>
        LastfmSquare = 0xf203,
        /// <summary>
        /// The toggle off value.
        /// </summary>
        ToggleOff = 0xf204,
        /// <summary>
        /// The toggle on value.
        /// </summary>
        ToggleOn = 0xf205,
        /// <summary>
        /// The bicycle value.
        /// </summary>
        Bicycle = 0xf206,
        /// <summary>
        /// The bus value.
        /// </summary>
        Bus = 0xf207,
        /// <summary>
        /// The ioxhost value.
        /// </summary>
        Ioxhost = 0xf208,
        /// <summary>
        /// The angellist value.
        /// </summary>
        Angellist = 0xf209,
        /// <summary>
        /// The cc value.
        /// </summary>
        Cc = 0xf20a,
        /// <summary>
        /// The ils value.
        /// </summary>
        Ils = 0xf20b,
        /// <summary>
        /// The meanpath value.
        /// </summary>
        Meanpath = 0xf20c,
    }
