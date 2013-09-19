using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcMultiLanguageSample2.Attributes {

    public class LocalizationDisplayNameAttribute : DisplayNameAttribute {

        private readonly DisplayAttribute _display;

        public LocalizationDisplayNameAttribute(string resourceName, Type resourceType) {
            _display = new DisplayAttribute() {
                ResourceType = resourceType,
                Name = resourceName
            };
        }

        public override string DisplayName {
            get {
                return _display.GetName();
            }
        }
    }

}