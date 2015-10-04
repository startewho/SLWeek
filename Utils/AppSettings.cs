using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using SLWeek.Models;

namespace SLWeek.Utils
{
    /// <summary>
    /// 设置帮助类 注意ApplicationDataContainer只能保存字符串类型，因此内部必须进行json序列化后再存储
    /// </summary>
    public class AppSettings
    {
        private readonly ApplicationDataContainer _settings = ApplicationData.Current.LocalSettings;

        
        public void SetValue<T>(string key, T value)
        {
            try
            {
                _settings.Values[key] = SerializerHelper.JsonSerializer(value);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            
        }

        /// <summary>
        /// Get the current value of the setting, or if it is not found, set the 
        /// setting to the default setting.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public T GetValue<T>(string key, T defaultValue)
        {
            T value;
            if (_settings.Values.ContainsKey(key))
            {
                value = SerializerHelper.JsonDeserialize<T>(_settings.Values[key].ToString());
            }
            else
            {
                value = defaultValue;
            }
            return value;
            
        }


        #region 主题色列表
        const string AccentColorsKeyName = "AccentColors";

        private static readonly List<Color> AccentColorsKeyNameDefault = new List<Color>()
                {
                    Color.FromArgb(255, 0xff, 0x88, 0x00),
                    Color.FromArgb(255, 241, 13, 162),
                    Color.FromArgb(255, 240, 67, 98),
                    Color.FromArgb(255, 239, 95, 65),
                    Color.FromArgb(255, 46, 204, 113),
                    Color.FromArgb(255, 52, 152, 219),
                    Color.FromArgb(255, 155, 89, 182),
                    Color.FromArgb(255, 52, 73, 94),
                    Color.FromArgb(255, 22, 160, 133),
                    Color.FromArgb(255, 39, 174, 96),
                    Color.FromArgb(255, 41, 128, 185),
                    Color.FromArgb(255, 142, 68, 173),
                    Color.FromArgb(255, 44, 62, 80),
                    Color.FromArgb(255, 241, 196, 15),
                    Color.FromArgb(255, 230, 126, 34),
                    Color.FromArgb(255, 231, 76, 60),
                    Color.FromArgb(255, 243, 156, 18),
                    Color.FromArgb(255, 211, 84, 0),
                    Color.FromArgb(255, 192, 57, 43)
                };

        /// <summary>
        /// 主题色列表
        /// </summary>
        public List<Color> AccentColors => GetValue(AccentColorsKeyName, AccentColorsKeyNameDefault);

        #endregion

        #region 所选主题色
        const string AccentColorKeyName = "AccentColor";
        /// <summary>
        /// 所选主题色
        /// </summary>
        public Color AccentColor
        {
            get
            {
                return GetValue(AccentColorKeyName, Color.FromArgb(255, 0xff, 0x88, 0x00));
            }
            set
            {
                SetValue(AccentColorKeyName, value);
              
            }
        }
        #endregion

        #region 所选栏目
        const string SelectChannelTypesKeyName = "SelectChannelTypes";

        private static readonly List<PostType> SelectChannelTypesDefault = new List<PostType>
        {
            new PostType {Name = "shehui", CNName = "社会", IsSelected = true},
            new PostType {Name = "wenhua", CNName = "文化", IsSelected = true},
            new PostType {Name = "keji", CNName = "科技", IsSelected = true}
        };

        /// <summary>
        /// 所选栏目
        /// </summary>
        public List<PostType> SelectChannelTypes
        {
            get
            {

                return GetValue(SelectChannelTypesKeyName, SelectChannelTypesDefault);
            }
            set
            {
                SetValue(SelectChannelTypesKeyName, value);
            }
        }

        #endregion


        #region 主题
        const string CurrentThemeKeyName = "CurrentTheme";
        const ElementTheme CurrentThemeDefault = ElementTheme.Dark;
        /// <summary>
        /// 主题
        /// </summary>
        public ElementTheme CurrentTheme
        {
            get
            {

                return GetValue(CurrentThemeKeyName, CurrentThemeDefault);
            }
            set
            {
                SetValue(CurrentThemeKeyName, value);
            }
        }
        #endregion

        #region
        const string IsAccentColorTitleBaKeyName = "IsAccentColorTitleBar";
        const bool IsAccentColorTitleBaKeyNameDefault = false;
        /// <summary>
        /// 标题栏底色设置
        /// </summary>
        public bool IsAccentColorTitleBar
        {
            get
            {
                return GetValue(IsAccentColorTitleBaKeyName, IsAccentColorTitleBaKeyNameDefault);
            }
            set
            {
                SetValue(IsAccentColorTitleBaKeyName, value);
            }
        }
    #endregion

        #region 是否启用双击退出
        const string IsEnableDoubleBackKeyPressToExitKeyName = "IsEnableDoubleBackKeyPressToExit";
        const bool IsEnableDoubleBackKeyPressToExitDefault = true;
        /// <summary>
        /// 是否启用双击退出
        /// </summary>
        public bool IsEnableDoubleBackKeyPressToExit
        {
            get
            {
                return GetValue(IsEnableDoubleBackKeyPressToExitKeyName, IsEnableDoubleBackKeyPressToExitDefault);
            }
            set
            {
                SetValue(IsEnableDoubleBackKeyPressToExitKeyName, value);
            }
        }
        #endregion

        #region 是否彻底退出
        const string IsCompletelyExitKeyName = "IsCompletelyExit";
        const bool IsCompletelyExitDefault = false;
        /// <summary>
        /// 是否彻底退出
        /// </summary>
        public bool IsCompletelyExit
        {
            get
            {
                return GetValue(IsCompletelyExitKeyName, IsCompletelyExitDefault);
            }
            set
            {
                SetValue(IsCompletelyExitKeyName, value);
            }
        }
        #endregion

        #region 是否显示状态栏
        const string IsShowStatusBarKeyName = "IsShowStatusBar";
        const bool IsShowStatusBarDefault = true;
        /// <summary>
        /// 是否显示状态栏
        /// </summary>
        public bool IsShowStatusBar
        {
            get
            {
                return GetValue(IsShowStatusBarKeyName, IsShowStatusBarDefault);
            }
            set
            {
                SetValue(IsShowStatusBarKeyName, value);
            }
        }
        #endregion



        #region 是否启用节省流量模式
        const string IsEnableSaveTrafficModeKeyName = "IsEnableSaveTrafficMode";
        const bool IsEnableSaveTrafficModeDefault = false;
        /// <summary>
        /// 是否启用节省流量模式 此模式下使用简单文章列表 图片点击后再显示
        /// </summary>
        public bool IsEnableSaveTrafficMode
        {
            get
            {
                return GetValue(IsEnableSaveTrafficModeKeyName, IsEnableSaveTrafficModeDefault);
            }
            set
            {
                SetValue(IsEnableSaveTrafficModeKeyName, value);
            }
        }
        #endregion

        #region 广告点击时间
        const string AdClickDateTimeKeyName = "AdClickDateTime";
        //const DateTime AdCool7ClickDateTimeDefault = new DateTime(2014, 5, 1);
        /// <summary>
        /// 用户点击广告的时间 每天只能点一次
        /// </summary>
        public DateTime AdClickDateTime
        {
            get
            {
                return GetValue(AdClickDateTimeKeyName, new DateTime(2014, 5, 1));
            }
            set
            {
                SetValue(AdClickDateTimeKeyName, value);
            }
        }
        #endregion

        #region 是否关闭广告
        const string IsEnableAdKeyName = "IsEnableAd";
        const bool IsEnableAdDefault = true;
        /// <summary>
        /// 是否启用广告 如果否则不显示广告
        /// </summary>
        public bool IsEnableAd
        {
            get
            {
                return GetValue(IsEnableAdKeyName, IsEnableAdDefault);
            }
            set
            {
                SetValue(IsEnableAdKeyName, value);
            }
        }
        #endregion

        #region 是否关闭广告
        const string IsEnableImageModeName = "IsEnableImageMode";
        const bool IsEnableImageModeDefault = true;
        /// <summary>
        /// 是否启用广告 如果否则不显示广告
        /// </summary>
        public bool IsEnableImageMode
        {
            get
            {
                return GetValue(IsEnableImageModeName, IsEnableImageModeDefault);
            }
            set
            {
                SetValue(IsEnableImageModeName, value);
            }
        }
        #endregion



        #region 评价时间
        const string ReviewDateTimeKeyName = "ReviewDateTime";
        //const DateTime AdCool7ClickDateTimeDefault = new DateTime(2014, 5, 1);
        /// <summary>
        /// 评价时间
        /// </summary>
        public DateTime ReviewDateTime
        {
            get
            {
                return GetValue(ReviewDateTimeKeyName, new DateTime(2014, 5, 1));
            }
            set
            {
                SetValue(ReviewDateTimeKeyName, value);
            }
        }
        #endregion
        private static volatile AppSettings _instance;
        private static object _locker = new object();

        private AppSettings() { }
        public static AppSettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_locker)
                    {
                        if (_instance == null)
                        {
                            _instance = new AppSettings();
                        }
                    }
                }
                return _instance;
            }
        }

        
    }
}
