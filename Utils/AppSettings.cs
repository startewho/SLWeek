using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.Storage;
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


        #region 主题
        const string SelectChannelTypesKeyName = "SelectChannelTypes";

        private static readonly List<PostType> SelectChannelTypesDefault = new List<PostType>
        {
            new PostType {Name = "shehui", CNName = "社会", IsSelected = false},
            new PostType {Name = "wenhua", CNName = "文化", IsSelected = false},
            new PostType {Name = "keji", CNName = "科技", IsSelected = true},
            new PostType {Name = "guoji", CNName = "国际", IsSelected = true},
            new PostType {Name = "shishang", CNName = "时尚", IsSelected = false},
            new PostType {Name = "renwu", CNName = "人物", IsSelected = true},
            new PostType {Name = "jingji", CNName = "经济", IsSelected = true},
            new PostType {Name = "shoucang", CNName = "收藏", IsSelected = true},
            new PostType {Name = "zhuanfang", CNName = "专访", IsSelected = false},
            new PostType {Name = "lvyou", CNName = "旅游", IsSelected = true},
            new PostType {Name = "yuanzhuo", CNName = "圆桌", IsSelected = false}
        };

        /// <summary>
        /// 主题
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
