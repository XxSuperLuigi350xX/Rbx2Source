﻿using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace Rbx2Source.Resources
{
    static class Settings
    {
        private static Dictionary<string, object> cache;
        private static RegistryKey rbx2Source;

        public static object GetSetting(string key)
        {
            if (!cache.ContainsKey(key))
                cache[key] = rbx2Source.GetValue(key);

            return cache[key];
        }

        public static T GetSetting<T>(string key)
        {
            object value = GetSetting(key);
            T result;

            if (value != null)
                result = (T)value;
            else
                result = default(T);

            return result;
        }

        public static void Save()
        {
            foreach (string key in cache.Keys)
            {
                object value = cache[key];

                if (value != null)
                {
                    rbx2Source.SetValue(key, cache[key]);
                }
            }
        }

        public static void SetSetting(string key, object value)
        {
            cache[key] = value;
        }

        public static void SaveSetting(string key, object value)
        {
            SetSetting(key, value);
            Save();
        }
        
        private static RegistryKey Open(RegistryKey current, string target)
        {
            return current.CreateSubKey(target, RegistryKeyPermissionCheck.ReadWriteSubTree);
        }


        static Settings()
        {
            RegistryKey currentUser = Registry.CurrentUser;
            RegistryKey software = Open(currentUser, "SOFTWARE");
            rbx2Source = Open(software, "Rbx2Source");
            cache = new Dictionary<string, object>();

            foreach (string key in rbx2Source.GetValueNames())
                SetSetting(key, rbx2Source.GetValue(key));

            if (GetSetting("InitializedV2") == null)
            {
                SetSetting("Username", "CloneTrooper1019");
                SetSetting("AssetId", "19027209");
                SetSetting("CompilerType", "Avatar");
                SetSetting("InitializedV2", true);
            }
        }
    }
}