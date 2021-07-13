﻿using Customization;
using PX.Api;
using PX.Data;
using System.Linq;

namespace PX.Commerce.WooCommerce.WC
{
    //Customization plugin is used to execute custom actions after customization project was published  
    public class WooCommerceConnector : CustomizationPlugin
    {
        private const string CODES = "WCCTAXCODES";
        private const string CLASSES = "WCCTAXCLASSES";

        //This method executed right after website files were updated, but before website was restarted
        //Method invoked on each cluster node in cluster environment
        //Method invoked only if runtimecompilation is enabled
        //Do not access custom code published to bin folder, it may not be loaded yet
        public override void OnPublished()
        {
            var graph = PXGraph.CreateInstance<SYSubstitutionMaint>();
            var taxCodeSubstitution = (SYSubstitution)graph.Substitution.Search<SYSubstitution.substitutionID>(CODES);
            var companyName = PXAccess.GetCompanyName();
            bool needToSave = false;

            if (taxCodeSubstitution == null)
            {
                graph.Substitution.Insert(new SYSubstitution { SubstitutionID = CODES });
                WriteLog($"{CODES} added to the company {companyName}");
                needToSave = true;
            }
            else
            {
                WriteLog($"{CODES} already exists in the company {companyName}");
            }

            var taxClassesSubstitution = graph.Select<SYSubstitution>().FirstOrDefault(s => s.SubstitutionID == CLASSES);

            if (taxClassesSubstitution == null)
            {
                graph.Substitution.Insert(new SYSubstitution { SubstitutionID = CLASSES });
                WriteLog($"{CLASSES} added to the company {companyName}");
                needToSave = true;
            }
            else
            {
                WriteLog($"{CLASSES} already exists in the company {companyName}");
            }

            if (needToSave)
                graph.Actions.PressSave();

        }
        //This method executed after customization was published and website was restarted.  
        public override void UpdateDatabase()
        {
            WriteLog("UpdateDatabase Event");
        }
    }
}
