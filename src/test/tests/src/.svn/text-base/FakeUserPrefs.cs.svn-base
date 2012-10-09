using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests {
    class FakeUserPrefs : Game.IUserPrefs {

        private Dictionary<string, int> cache = new Dictionary<string, int>();
        private Dictionary<string, string> dic = new Dictionary<string, string>();
        private Dictionary<string, bool> boolCache = new Dictionary<string, bool>();

        public int GetInt(string key, int defaultValue) {
            if (cache.ContainsKey(key)) {
                return cache[key];
            }
            return defaultValue;
        }

        public void clearString(string key) {
            dic.Remove(key);
        }

		public string GetString(string key, string defaultResponse) {
			if (dic.ContainsKey(key)) {
                return dic[key];
            }

            return defaultResponse;
		}

		public void SetString(string a, string b) {
            if (b == null || b.Length == 0) {
                throw new ArgumentException("must specify value");
            }
            dic[a] = b;
		}

        public void SetInt(string key, int value) {
            cache[key] = value;
        }

        public bool GetBool(string key, bool defaultValue) {
            if (boolCache.ContainsKey(key)) {
                return boolCache[key];
            }
            return defaultValue;
        }

        public void SetBool(string key, bool value) {
            boolCache[key] = value;
        }
    }
}
