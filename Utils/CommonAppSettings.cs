using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;
using SLWeek.Models;


namespace SLWeek.Utils
{
    /// <summary>
    /// 设置帮助类 注意ApplicationDataContainer只能保存字符串类型，因此内部必须进行json序列化后再存储
    /// </summary>
    public class CommonAppSettings
    {
        private readonly ApplicationDataContainer _settings = Windows.Storage.ApplicationData.Current.LocalSettings;

        
        public void SetValue<T>(string key, T value)
        {
            try
            {
                _settings.Values[key] = SerializerHelper.ToJson<T>(value);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
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
                value = SerializerHelper.FromJson<T>(_settings.Values[key].ToString());
            }
            else
            {
                value = defaultValue;
            }
            return value;
            
        }


        #region 主题
        const string SelectChannelTypesKeyName = "CurrentTheme";

        private static readonly List<PostType> SelectChannelTypesDefault = new List<PostType>()
        {
            new PostType() {Name = "shehui", CNName = "社会", IsSelected = true},
            new PostType() {Name = "wenhua", CNName = "文化", IsSelected = true},
            new PostType() {Name = "keji", CNName = "科技", IsSelected = true}
        };

        /// <summary>
        /// 主题
        /// </summary>
        public List<PostType> SelectChannelTypes
        {
            get
            {

                return GetValue<List<PostType>>(SelectChannelTypesKeyName, SelectChannelTypesDefault);
            }
            set
            {
                SetValue<List<PostType>>(SelectChannelTypesKeyName, value);
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

                return GetValue<ElementTheme>(CurrentThemeKeyName, CurrentThemeDefault);
            }
            set
            {
                SetValue<ElementTheme>(CurrentThemeKeyName, value);
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
                return GetValue<bool>(IsEnableDoubleBackKeyPressToExitKeyName, IsEnableDoubleBackKeyPressToExitDefault);
            }
            set
            {
                SetValue<bool>(IsEnableDoubleBackKeyPressToExitKeyName, value);
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
                return GetValue<bool>(IsCompletelyExitKeyName, IsCompletelyExitDefault);
            }
            set
            {
                SetValue<bool>(IsCompletelyExitKeyName, value);
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
                return GetValue<bool>(IsShowStatusBarKeyName, IsShowStatusBarDefault);
            }
            set
            {
                SetValue<bool>(IsShowStatusBarKeyName, value);
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
                return GetValue<bool>(IsEnableSaveTrafficModeKeyName, IsEnableSaveTrafficModeDefault);
            }
            set
            {
                SetValue<bool>(IsEnableSaveTrafficModeKeyName, value);
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
                return GetValue<DateTime>(AdClickDateTimeKeyName, new DateTime(2014, 5, 1));
            }
            set
            {
                SetValue<DateTime>(AdClickDateTimeKeyName, value);
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
                return GetValue<bool>(IsEnableAdKeyName, IsEnableAdDefault);
            }
            set
            {
                SetValue<bool>(IsEnableAdKeyName, value);
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
                return GetValue<bool>(IsEnableImageModeName, IsEnableImageModeDefault);
            }
            set
            {
                SetValue<bool>(IsEnableImageModeName, value);
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
                return GetValue<DateTime>(ReviewDateTimeKeyName, new DateTime(2014, 5, 1));
            }
            set
            {
                SetValue<DateTime>(ReviewDateTimeKeyName, value);
            }
        }
        #endregion
        private static volatile CommonAppSettings _instance;
        private static object _locker = new object();

        private CommonAppSettings() { }
        public static CommonAppSettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_locker)
                    {
                        if (_instance == null)
                        {
                            _instance = new CommonAppSettings();
                        }
                    }
                }
                return _instance;
            }
        }



    }
}
