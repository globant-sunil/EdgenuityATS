using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeWebDriver.Enums
{
    /// <summary>
    /// Role types to test different privilegies.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Roles
    {
        // TODO: We should have different login Roles (Teacher / Student / Admin.. etc ).

        Teacher,
        Admin,
        Student,
        None
    }
}
