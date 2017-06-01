using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Configuration;
namespace Frame.Web.Framework.Exceptions
{
    public class LoggingHandlerData : ExceptionHandlerData
    {
        private static readonly AssemblyQualifiedTypeNameConverter typeConverter = new AssemblyQualifiedTypeNameConverter();
        private const string title = "title";
        private const string formatterType = "formatterType";

        [ConfigurationProperty(title, IsRequired = true)]
        public string Title
        {
            get { return (string)this[title]; }
            set { this[title] = value; }
        }

        [ConfigurationProperty(formatterType, IsRequired = true)]
        public string FormatterTypeName
        {
            get { return (string)this[formatterType]; }
            set { this[formatterType] = value; }
        }

        public Type FormatterType
        {
            get { return (Type)typeConverter.ConvertFrom(FormatterTypeName); }
            set { FormatterTypeName = typeConverter.ConvertToString(value); }
        }
        public override IExceptionHandler BuildExceptionHandler()
        {
            return new LoggingHandler(Title, FormatterType);
        }

    }
}
