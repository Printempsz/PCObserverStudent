using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCObserverStudent
{
    class WhiteList
    {
        private Hashtable whitelist;
        public WhiteList()
        {

            whitelist = new Hashtable();
            whitelist.Add("RuntimeBroker", "a");
            whitelist.Add("svchost", "a");
            whitelist.Add("explorer", "a");
            whitelist.Add("csrss", "a");
            whitelist.Add("SearchIndexer", "a");
            whitelist.Add("coherence", "a");
            whitelist.Add("SkypeHost", "a");
            whitelist.Add("winlogon", "a");
            whitelist.Add("prl_cc", "a");
            whitelist.Add("OneDrive", "a");
            whitelist.Add("taskhostw", "a");
            whitelist.Add("TabTip32", "a");
            whitelist.Add("TrustedInstaller", "a");
            whitelist.Add("TiWorker", "a");
            whitelist.Add("devenv", "a");
            whitelist.Add("fontdrvhost", "a");
            whitelist.Add("ServiceHub.VSDetouredHost", "a");
            whitelist.Add("dllhost", "a");
            whitelist.Add("Memory Compression", "a");
            whitelist.Add("SystemSettingsBroker", "a");
            whitelist.Add("ApplicationFrameHost", "a");
            whitelist.Add("sihost", "a");
            whitelist.Add("ServiceHub.Host.Node.x86", "a");
            whitelist.Add("ctfmon", "a");
            whitelist.Add("ScriptedSandbox64", "a");
            whitelist.Add("ShellExperienceHost", "a");
            whitelist.Add("sedsvc", "a");
            whitelist.Add("ServiceHub.DataWarehouseHost", "a");
            whitelist.Add("MSASCuiL", "a");
            whitelist.Add("PeopleExperienceHost", "a");
            whitelist.Add("smss", "a");
            whitelist.Add("prl_tools", "a");
            whitelist.Add("wininit", "a");
            whitelist.Add("LockApp", "a");
            whitelist.Add("ServiceHub.IdentityHos", "a");
            whitelist.Add("ServiceHub.RoslynCodeAnalysisService32", "a");
            whitelist.Add("prl_tools_service", "a");
            whitelist.Add("ServiceHub.SettingsHost", "a");
            whitelist.Add("SearchUI", "a");
            whitelist.Add("TabTip", "a");
            whitelist.Add("WmiPrvSE ", "a");
            whitelist.Add("spoolsv", "a");
            whitelist.Add("VBCSCompiler", "a");
            whitelist.Add("conhost", "a");
            whitelist.Add("dwm", "a");
            whitelist.Add("SystemSettingsAdminFlows", "a");
            whitelist.Add("lsass", "a");
            whitelist.Add("services", "a");
            whitelist.Add("WUDFHost", "a");
            whitelist.Add("SecurityHealthService", "a");
            whitelist.Add("ServiceHub.Host.CLR.x86", "a");
            whitelist.Add("StandardCollector.Service", "a");
            whitelist.Add("System", "a");
            whitelist.Add("ChsIME", "a");
            whitelist.Add("Idle", "a");
            whitelist.Add("WmiPrvSE", "a");
            whitelist.Add("PCObserve", "a");
            whitelist.Add("PCObserverStudent", "a");
            whitelist.Add("ServiceHub.IdentityHost", "a");
        }

        public string check(ArrayList pros)
        {
            string s = "有如下白名单中未配置的进程:\r\n";
            foreach (string pro in pros)
            {
                if (!whitelist.ContainsKey(pro))
                {
                    s = s + pro + "\r\n";
                }
            }
            return s;
        }
    }
}
