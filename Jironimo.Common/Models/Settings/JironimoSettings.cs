using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jironimo.Common.Models.Settings
{
    public class JironimoSettings
    {
        public JironimoSettings(IConfiguration configuration)
        {
            IConfigurationSection section = configuration.GetSection("PdfEscapeSettings");
            section.Bind(this);
        }

        public JironimoSettings() { }
    }
}
