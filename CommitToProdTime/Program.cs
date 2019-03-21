using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace CommitToProdTime
{
    class Program
    {
        IDictionary<string, TimeSpan> deployTimes = new Dictionary<string, TimeSpan>();
        RestRequest request = new RestRequest(Method.GET);

        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            request.AddHeader("Postman-Token", "34838981-39b5-4248-b4cb-045323c1e71a");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Authorization", "Basic OnFsbzJwbGJmNm5rbWRmaHU1enZ4cm1ia2htYjN1b2h0NHVwZHZxbHM0ZXU0dGZvbDZlaGE=");

            CLE();
            URAX();
            SOFTOFFER();
            new WriteToFile().Write(deployTimes);

            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }

        private void CLE()
        {
            string DistanceCalculator = "1405";
            string FindOrder = "1442";
            string GenericOrderFeed = "1737";
            string GOF = "1437";
            string GenericOrderFeedCI = "1442";
            string LoggingSDK = "1835";
            string OrderLoader = "1769";
            string PartnerFeedRDM = "1418";
            string PartnerFeedRDMCI = "1419";
            string PartnerGroupFeed = "1432";
            string Rules = "1430";
            string SearchService = "1735";
            string SearchServiceCI = "1722";
            string SQLServerDBCI = "1431";
            string StockCarLive = "1433";
            string StockCarLiveCI = "1434";

            


            IList<TimeSpan> CLETimes = new List<TimeSpan>();

            TimeSpan DistanceCalculatorTS = getDataFromAzureDevops(DistanceCalculator, request);
            CLETimes.Add(DistanceCalculatorTS);
            deployTimes.Add("DistanceCalculatorTS", DistanceCalculatorTS);

            TimeSpan FindOrderTS = getDataFromAzureDevops(FindOrder, request);
            CLETimes.Add(FindOrderTS);
            deployTimes.Add("FindOrderTS", FindOrderTS);

            TimeSpan GenericOrderFeedTS = getDataFromAzureDevops(GenericOrderFeed, request);
            CLETimes.Add(GenericOrderFeedTS);
            deployTimes.Add("GenericOrderFeedTS", GenericOrderFeedTS);

            TimeSpan GOFTS = getDataFromAzureDevops(GOF, request);
            CLETimes.Add(GOFTS);
            deployTimes.Add("GOFTS", GOFTS);

            TimeSpan GenericOrderFeedCITS = getDataFromAzureDevops(GenericOrderFeedCI, request);
            CLETimes.Add(GenericOrderFeedCITS);
            deployTimes.Add("GenericOrderFeedCITS", GenericOrderFeedCITS);

            TimeSpan LoggingSDKTS = getDataFromAzureDevops(LoggingSDK, request);
            CLETimes.Add(LoggingSDKTS);
            deployTimes.Add("LoggingSDKTS", LoggingSDKTS);

            TimeSpan OrderLoaderTS = getDataFromAzureDevops(OrderLoader, request);
            CLETimes.Add(OrderLoaderTS);
            deployTimes.Add("OrderLoaderTS", OrderLoaderTS);

            TimeSpan PartnerFeedRDMTS = getDataFromAzureDevops(PartnerFeedRDM, request);
            CLETimes.Add(PartnerFeedRDMTS);
            deployTimes.Add("PartnerFeedRDMTS", PartnerFeedRDMTS);

            TimeSpan PartnerFeedRDMCITS = getDataFromAzureDevops(PartnerFeedRDMCI, request);
            CLETimes.Add(PartnerFeedRDMCITS);
            deployTimes.Add("PartnerFeedRDMCITS", PartnerFeedRDMCITS);

            TimeSpan PartnerGroupFeedTS = getDataFromAzureDevops(PartnerGroupFeed, request);
            CLETimes.Add(PartnerGroupFeedTS);
            deployTimes.Add("PartnerGroupFeedTS", PartnerGroupFeedTS);

            TimeSpan RulesTS = getDataFromAzureDevops(Rules, request);
            CLETimes.Add(RulesTS);
            deployTimes.Add("RulesTS", RulesTS);

            TimeSpan SearchServiceTS = getDataFromAzureDevops(SearchService, request);
            CLETimes.Add(SearchServiceTS);
            deployTimes.Add("SearchServiceTS", SearchServiceTS);

            TimeSpan SearchServiceCITS = getDataFromAzureDevops(SearchServiceCI, request);
            CLETimes.Add(SearchServiceCITS);
            deployTimes.Add("SearchServiceCITS", SearchServiceCITS);

            TimeSpan SQLServerDBCITS = getDataFromAzureDevops(SQLServerDBCI, request);
            deployTimes.Add("SQLServerDBCITS", SQLServerDBCITS);
            CLETimes.Add(SQLServerDBCITS);


            TimeSpan StockCarLiveTS = getDataFromAzureDevops(StockCarLive, request);
            deployTimes.Add("StockCarLiveTS", StockCarLiveTS);
            CLETimes.Add(StockCarLiveTS);

            TimeSpan StockCarLiveCITS = getDataFromAzureDevops(StockCarLiveCI, request);
            deployTimes.Add("StockCarLiveCITS", StockCarLiveCITS);
            CLETimes.Add(StockCarLiveCITS);

            TimeSpan tempCleTimes = new TimeSpan(0);
            foreach(TimeSpan ts in CLETimes)
            {
                tempCleTimes = tempCleTimes.Add(ts);
            }
            Console.WriteLine("CLE Total Time: " + tempCleTimes.TotalHours);
            deployTimes.Add("CLE total build time" , tempCleTimes);


            string defIdDistanceCalc = "15";
            string defIdFindOrder = "21";
            string defIdGof = "20";
            string defIdHPLS = "27";
            string defIdOrderLoader = "28";
            string defIdPartnerFeedRDM = "16";
            string defIdPartnerGroupFeed = "18";
            string defIdRules = "17";
            string defIdSearchService = "26";
            string defIdStockCarLive = "19";

            SaveTimesForRelease(request, defIdDistanceCalc, "DistanceCalc");
            SaveTimesForRelease(request, defIdFindOrder, "FindOrder");
            SaveTimesForRelease(request, defIdGof, "GOF");
            SaveTimesForRelease(request, defIdHPLS, "HPLS");
            SaveTimesForRelease(request, defIdOrderLoader, "OrderLoader");
            SaveTimesForRelease(request, defIdPartnerFeedRDM, "PartnerFeedRDM");
            SaveTimesForRelease(request, defIdPartnerGroupFeed, "PartnerGroupFeed");
            SaveTimesForRelease(request, defIdRules, "Rules");
            SaveTimesForRelease(request, defIdSearchService, "SearchService");
            SaveTimesForRelease(request, defIdStockCarLive, "StockCarLive");
        }


        private void SaveTimesForRelease(RestRequest request, string defId, string name) 
        {

            var releases = GetDeployment(request, defId);
            TimeSpan CLEDistCalcDevEnv = GetAvgTimeForEnviroment("Dev", releases);
            TimeSpan CLEDistCalcQAEnv = GetAvgTimeForEnviroment("QA", releases);
            TimeSpan CLEDistCalcProdEnv = GetAvgTimeForEnviroment("Prod", releases);
            deployTimes.Add(name + "DevEnv", CLEDistCalcDevEnv);
            deployTimes.Add(name + "QAEnv", CLEDistCalcQAEnv);
            deployTimes.Add(name + "ProdEnv", CLEDistCalcProdEnv);
        }

        private void SOFTOFFER()
        {
            string SoftOffer = "87";
            string SoftOfferBuildPR = "73";
            string SoftOfferWeb = "75";
            string SoftOfferWebBuildPR = "76";

            string definitionIdSO = "4";
            string definitionIdSOWeb = "2";

            var SoftOfferBuildPRTimeSpan = getDataFromAzureDevops(SoftOfferBuildPR, request);
            var SOTimeSpanTimeSpan = getDataFromAzureDevops(SoftOffer, request);
            var SoftOfferWebTimeSPan = getDataFromAzureDevops(SoftOfferWeb, request);
            var SoftOfferWebBuildPRTimeSpan = getDataFromAzureDevops(SoftOfferWebBuildPR, request);

            deployTimes.Add("SoftOfferBuildPRTimeSpan", SoftOfferBuildPRTimeSpan);
            deployTimes.Add("SOTimeSpanTimeSpan", SOTimeSpanTimeSpan);
            deployTimes.Add("SoftOfferWebTimeSPan", SoftOfferWebTimeSPan);
            deployTimes.Add("SoftOfferWebBuildPRTimeSpan", SoftOfferWebBuildPRTimeSpan);

            Console.WriteLine("Avg Build Time SoftOfferBuildPR: " + SoftOfferBuildPRTimeSpan);
            Console.WriteLine("Avg Build Time SoftOffer: " + SOTimeSpanTimeSpan);
            Console.WriteLine("Avg Build Time SoftOfferWeb: " + SoftOfferWebTimeSPan);
            Console.WriteLine("Avg Build Time SoftOfferWebBuildPR: " + SoftOfferWebBuildPRTimeSpan);

            var releases = GetDeployment(request, definitionIdSO);

            TimeSpan SODevEnv = GetAvgTimeForEnviroment("Dev", releases);
            TimeSpan SOSysTestEnv = GetAvgTimeForEnviroment("Systems Test", releases);
            TimeSpan SOTestEnv = GetAvgTimeForEnviroment("Test", releases);
            TimeSpan SOProdEnv = GetAvgTimeForEnviroment("Prod", releases);

            deployTimes.Add("SODevEnv", SODevEnv);
            deployTimes.Add("SOSysTestEnv", SOSysTestEnv);
            deployTimes.Add("SOTestEnv", SOTestEnv);
            deployTimes.Add("SOProdEnv", SOTestEnv);


            Console.WriteLine("-------SOFT OFFER------");
            Console.WriteLine("Avg Release Time Dev: " + SODevEnv);
            Console.WriteLine("Avg Release Time Sys Test: " + SOSysTestEnv);
            Console.WriteLine("Avg Release Time Test: " + SOTestEnv);
            Console.WriteLine("Avg Release Time Prod: " + SOProdEnv);

            TimeSpan AvrageCommitToProdSoftOffer = SoftOfferBuildPRTimeSpan + SOTimeSpanTimeSpan+ SODevEnv+  SOSysTestEnv + SOSysTestEnv + SOProdEnv;
            Console.WriteLine("Total Avrage Time SoftOffer Commit to Prod: in Hours " + AvrageCommitToProdSoftOffer.TotalHours);

            releases = GetDeployment(request, definitionIdSOWeb);

             SODevEnv = GetAvgTimeForEnviroment("Dev", releases);
             SOSysTestEnv = GetAvgTimeForEnviroment("Systems Test", releases);
             SOTestEnv = GetAvgTimeForEnviroment("Test", releases);
             SOProdEnv = GetAvgTimeForEnviroment("Prod", releases);

            deployTimes.Add("SOWebDevEnv", SODevEnv);
            deployTimes.Add("SOWebSysTestEnv", SOSysTestEnv);
            deployTimes.Add("SOWebTestEnv", SOTestEnv);
            deployTimes.Add("SOWebProdEnv", SODevEnv);

            Console.WriteLine("-------SOFT OFFER WEB------");
            Console.WriteLine("Avg Release Time Dev: " + SODevEnv);
            Console.WriteLine("Avg Release Time Sys Test: " + SOSysTestEnv);
            Console.WriteLine("Avg Release Time Test: " + SOTestEnv);
            Console.WriteLine("Avg Release Time Prod: " + SOProdEnv);

            TimeSpan AvrageCommitToProdSoftOfferWeb = SoftOfferWebTimeSPan + SoftOfferWebBuildPRTimeSpan + SODevEnv + SOSysTestEnv + SOSysTestEnv + SOProdEnv;
            Console.WriteLine("Total Avrage Time SoftOffer Web Commit to Prod in Hours: " + AvrageCommitToProdSoftOfferWeb.TotalHours);


        }

        private void URAX()
        {
            string URAXPR = "1352";
            string URAXSF = "1353";

            string definitionId = "14";

            TimeSpan URAXPRTimeSpan = getDataFromAzureDevops(URAXPR, request);
            TimeSpan URAXSFTimeSpan = getDataFromAzureDevops(URAXSF, request);

            deployTimes.Add("URAXPR", URAXPRTimeSpan);
            deployTimes.Add("URAXSF", URAXSFTimeSpan);

            Console.WriteLine("-------------URAX---------------");
            Console.WriteLine("Avg Build Time URAXPR: " + URAXPRTimeSpan);
            Console.WriteLine("Avg Build Time URAXSF: " + URAXSFTimeSpan);

            var releases = GetDeployment(request, definitionId);

            TimeSpan URAXDevEnv = GetAvgTimeForEnviroment("Dev", releases);
            TimeSpan URAXTestEnv = GetAvgTimeForEnviroment("Test", releases);
            TimeSpan URAXQaEnv = GetAvgTimeForEnviroment("QA", releases);
            TimeSpan URAXProdEnv = GetAvgTimeForEnviroment("Prod", releases);

            deployTimes.Add("URAXDevEnv", URAXDevEnv);
            deployTimes.Add("URAXTestEnv", URAXTestEnv);
            deployTimes.Add("URAXQaEnv", URAXQaEnv);
            deployTimes.Add("URAXProdEnv", URAXProdEnv);



            Console.WriteLine("Avg Release Time Dev: " + URAXDevEnv);
            Console.WriteLine("Avg Release Time Test: " + URAXTestEnv);
            Console.WriteLine("Avg Release Time Qa: " + URAXQaEnv);
            Console.WriteLine("Avg Release Time Prod: " + URAXProdEnv);

            TimeSpan AvrageCommitToProdURAXWeb = URAXPRTimeSpan + URAXSFTimeSpan + URAXDevEnv + URAXTestEnv + URAXQaEnv + URAXProdEnv;
            deployTimes.Add("AvrageCommitToProdURAXWeb", AvrageCommitToProdURAXWeb);
            Console.WriteLine("Total Avrage Time URAX Commit to Prod: " + AvrageCommitToProdURAXWeb.TotalHours);
            Console.WriteLine("----------------------------");
        }

        private TimeSpan GetAvgTimeForEnviroment(string environment, IList<Release> releases)
        {
            var totalTime = new TimeSpan(0);
            var count = 0;
            foreach (Release r in releases)
            {
                var envs = r.environments;
                if(envs.Count > 0) { 
                    if (environment.Equals("Prod"))
                    {
                        if(envs.TryGetValue("QA", out Environment tempTimeEnv))
                        {
                            if (envs.TryGetValue(environment, out Environment EnvTimes) ||
                                envs.TryGetValue(environment.ToUpper(), out EnvTimes))
                            {
                                totalTime = totalTime = totalTime.Add(EnvTimes.finishTime - tempTimeEnv.finishTime);
                                count++;
                            }
                        }else if(envs.TryGetValue("Test", out tempTimeEnv))
                        {
                            if (envs.TryGetValue(environment, out Environment EnvTimes))
                            {
                                totalTime = totalTime = totalTime.Add(EnvTimes.finishTime - tempTimeEnv.finishTime);
                                count++;
                            }
                        }

                    }else if (environment.Equals("QA"))
                    {
                        if (envs.TryGetValue("Test", out Environment tempTimeEnv))
                        {
                            if (envs.TryGetValue(environment, out Environment EnvTimes))
                            {
                                totalTime = totalTime = totalTime.Add(EnvTimes.finishTime - tempTimeEnv.finishTime);
                                count++;
                            }
                        }
                        if (envs.TryGetValue("DEV", out tempTimeEnv))
                        {
                            if (envs.TryGetValue(environment, out Environment EnvTimes))
                            {
                                totalTime = totalTime = totalTime.Add(EnvTimes.finishTime - tempTimeEnv.finishTime);
                                count++;
                            }
                        }
                    }
                    else if (environment.Equals("Test"))
                    {
                        if (envs.TryGetValue("Dev", out Environment tempTimeEnv))
                        {
                            if (envs.TryGetValue(environment, out Environment EnvTimes))
                            {
                                totalTime = totalTime = totalTime.Add(EnvTimes.finishTime - tempTimeEnv.finishTime);
                                count++;
                            }
                        }
                        if (envs.TryGetValue("Systems Test", out tempTimeEnv))
                        {
                            if (envs.TryGetValue(environment, out Environment EnvTimes))
                            {
                                totalTime = totalTime = totalTime.Add(EnvTimes.finishTime - tempTimeEnv.finishTime);
                                count++;
                            }
                        }
                    }
                    else if (environment.Equals("Systems Test"))
                    {
                        if (envs.TryGetValue("Dev", out Environment tempTimeEnv))
                        {
                            if (envs.TryGetValue(environment, out Environment EnvTimes))
                            {
                                totalTime = totalTime = totalTime.Add(EnvTimes.finishTime - tempTimeEnv.finishTime);
                                count++;
                            }
                        }
                    }
                    else if (environment.Equals("Dev"))
                    {
                        if (envs.TryGetValue(environment, out Environment EnvTimes) ||
                            envs.TryGetValue(environment.ToUpper(), out EnvTimes))
                        {

                            DateTime finishTimeOfBuild = getFinishTimeOfBuild("https://volvocargroup.visualstudio.com/DSPA/_apis/build/builds?api-version=5.0&buildIds=" + r.buildId);
                            totalTime = totalTime.Add(EnvTimes.finishTime - finishTimeOfBuild);
                            count++;
                        }
                    }
                    
                    
                    else { 

                        if(envs.TryGetValue(environment, out Environment EnvTimes))
                        {

                            totalTime = totalTime.Add(EnvTimes.finishTime - EnvTimes.startTime);
                            count++;
                        }
                    }
                }
            }

            
            if(count > 0) { 
                return new TimeSpan(totalTime.Ticks / count);
            }
            return new TimeSpan();
        }

        private DateTime getFinishTimeOfBuild(string URL)
        {
            var client = new RestClient(URL);
            IRestResponse response = client.Execute(request);
            Dictionary<string, object> values = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content);

            if(values.TryGetValue("value", out object build))
            {
                var buildArray = ((JArray)build);
                foreach(JToken buildToken in buildArray)
                {
                    return buildToken.Value<DateTime>("finishTime");
                    
                }
              
            }

            return new DateTime();

        }

        private IList<Release> GetDeployment(RestRequest request, string definitionId)
        {
            var client = new RestClient("https://volvocargroup.vsrm.visualstudio.com/DSPA/_apis/release/deployments?api-version=5.0&$top=10000&definitionId=" + definitionId);
            IRestResponse response = client.Execute(request);
            Dictionary<string, object> values = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content);

            if (values.TryGetValue("value", out object releaseObj))
            {
                var releaseTemp = (JArray)releaseObj;
                IList<Release> releases = new List<Release>();
                var buildId = "";
                foreach (JToken re in releaseTemp)
                {
                    var releaseId = re.Value<JObject>("release").Value<string>("id");
                    if(!releases.Contains(new Release {id = releaseId })) {
                        Release release = new Release { id = releaseId};
                        
                        var artifactArray = re.Value<JObject>("release").Value<JArray>("artifacts");
                        foreach (JToken token in artifactArray)
                        {
                            if (token.Value<string>("type").Equals("Build"))
                            {
                                buildId = token.Value<JObject>("definitionReference").Value<JToken>("version").Value<string>("id");
                                release.buildId = buildId;
                            }
                        }

                        releases.Add(release);
                    }
                    
                }

                return GetTimeLineForRelease(releases, request);
            }
            return null;
        }

        private IList<Release> GetTimeLineForRelease(IList<Release> releases, RestRequest request)
        {
            
            foreach (Release release in releases)
            {
                var enviroments = new List<Environment>();
                var client = new RestClient("https://volvocargroup.vsrm.visualstudio.com/DSPA/_apis/release/releases/" + release.id + "?api-version=5.0");
                IRestResponse response = client.Execute(request);
                Dictionary<string, object> values = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content);
                if(values.TryGetValue("name", out object nameObj))
                {
                    release.name = nameObj.ToString();
                }

                if (values.TryGetValue("environments", out object releaseObj))
                {
                    var releaseTemp = (JArray)releaseObj;
                    foreach (JToken re in releaseTemp)
                    {
                        if(getValueString(re, "status").Equals("succeeded"))
                        {
                            var environmentStringTemp = getValueString(re, "name");
                            
                            var deploySteps = re.Value<JArray>("deploySteps");
                            foreach(JToken deployStep in deploySteps)
                            {
                                if (!enviroments.Contains(new Environment { enviroment = environmentStringTemp }))
                                {
                                    if (getValueString(deployStep, "status").Equals("succeeded"))
                                    {
                                        var phases = deployStep.Value<JArray>("releaseDeployPhases");
                                        foreach (var phase in phases)
                                        {
                                            var deploymentJobs = phase.Value<JArray>("deploymentJobs");
                                            foreach (var deploymentJob in deploymentJobs)
                                            {
                                                var job = deploymentJob.Value<JToken>("job");
                                                var startTime = new DateTime();
                                                if (environmentStringTemp.Equals("Dev"))
                                                {
                                                    startTime = job.Value<DateTime>("startTime");
                                                }
                                                else
                                                {
                                                    startTime = job.Value<DateTime>("startTime");
                                                }


                                                var finishTime = job.Value<DateTime>("finishTime");
                                                if (!release.environments.ContainsKey(environmentStringTemp))
                                                {

                                                    release.environments.Add(environmentStringTemp, new Environment
                                                    {
                                                        enviroment = environmentStringTemp,
                                                        startTime = startTime,
                                                        finishTime = finishTime,
                                                    });
                                                    

                                                }


                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
                
                
            }


            return releases;




        }

        private string getValueString(JToken re, string v)
        {
            return re.Value<string>(v);
        }

        private TimeSpan GetAvgTimeForBuild(IList<string> buildNumbers, RestRequest request)
        {
            TimeSpan totalBuildTime = new TimeSpan();
            int count = 0;
            foreach (var buildNumber in buildNumbers)
            {
                
                var name = "";
                var startTime = "";
                var finishTime = "";
                var client = new RestClient("https://volvocargroup.visualstudio.com/DSPA/_apis/build/builds/"+buildNumber+"/timeline?api-version=4.1");
                IRestResponse response = client.Execute(request);
                Dictionary<string, object> values = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content);
                if (values != null && values.TryGetValue("records", out object buildRecordsObj))
                {
                    var buildRecord = (JArray)buildRecordsObj;
                    foreach (JToken re in buildRecord)
                    {
                        name = re.Value<string>("name");
                        if (name.Equals("Initialize Agent"))
                        {
                            startTime = re.Value<string>("startTime");
                        }
                        else if (name.Equals("Finalize Job"))
                        {
                            finishTime = re.Value<string>("finishTime");
                        }
                    }

                }
                if (!startTime.Equals("") && !finishTime.Equals(""))
                {
                    var startTemp = DateTime.Parse(startTime);
                    var finishTemp = DateTime.Parse(finishTime);
                    count++;
                    totalBuildTime = (finishTemp.Subtract(startTemp)).Add(totalBuildTime);
                }
            }
            if(count == 0)
            {
                return new TimeSpan(0);
            }
            return new TimeSpan(totalBuildTime.Ticks / count);


        }

        private TimeSpan getDataFromAzureDevops(string definitionId , RestRequest request)
        {
            var client = new RestClient("https://volvocargroup.visualstudio.com/DSPA/_apis/build/builds?api-version=5.0&definitions="+ definitionId);
            IRestResponse response = client.Execute(request);
            Dictionary<string, object> values = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content);
            IList<string> buildNumbers = new List<string>();
            if (values.TryGetValue("value", out object buildObj))
            {
               
                var buildTemp = (JArray)buildObj;
                foreach (JToken re in buildTemp)
                {
                    if (re.Value<string>("result").Equals("succeeded"))
                    {

                        var buildNumber = re.Value<string>("id");
                        if (!buildNumbers.Contains(buildNumber))
                        {
                            buildNumbers.Add(buildNumber);
                        }
                    }
                }
                
            }

            return GetAvgTimeForBuild(buildNumbers, request);


        }
    }
}
