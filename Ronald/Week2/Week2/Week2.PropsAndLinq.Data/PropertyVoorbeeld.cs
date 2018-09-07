using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.PropsAndLinq.Data
{
    /// <summary>
    /// Properties Voorbeeld
    /// </summary>
    public class PropertyVoorbeeld
    {
        private string voornaam;

        public PropertyVoorbeeld() : this("")
        {
         
        }

        public PropertyVoorbeeld(string achternaam)
        {
            AchterNaam = achternaam;
        }

        /// <summary>
        /// Property 
        /// </summary>
        public string VoorNaam
        {
            get { return voornaam; }
            set
            {
                if (string.IsNullOrEmpty(voornaam))
                {
                    voornaam = value;
                }
            }
        }

        /// <summary>
        /// Automatic Property (private setter)
        /// </summary>
        public string AchterNaam { get; private set; }

        /// <summary>
        /// ReadOnly property als een expression-body 
        /// </summary>
        public string Naam => $"{voornaam} {AchterNaam}";

        /// <summary>
        /// Property read-only 
        /// </summary>
        //public string Naam { get { return $"{voornaam} {AchterNaam}"; } }

    }
}
