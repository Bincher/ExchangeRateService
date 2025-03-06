using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using static System.Net.WebRequestMethods;
using System.Security.Policy;
using HtmlAgilityPack;
using System.Web;
using System.Net.Http;
using Newtonsoft.Json;

namespace ExchangeRateService
{

    

    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private static System.Timers.Timer timer;

        public Form1()
        {

            InitializeComponent();
            LoadExchangeRates();

            timer = new System.Timers.Timer(1000);
            timer.Elapsed += OnTimerElapsed;
            timer.AutoReset = false;
            timer.Enabled = true;
        }

        private void LoadExchangeRates()
        {
            string apiKey = "api-key";

            string todayDate = DateTime.Now.ToString("yyyyMMdd");
            string yesterdayDate = DateTime.Today.AddDays(-1).ToString("yyyyMMdd");

            string todayExURL = "https://www.koreaexim.go.kr/site/program/financial/exchangeJSON?authkey=" +
                apiKey +
                "&searchdate=" +
                todayDate +
                "&data=AP01";
            string yesterdayExURL = "https://www.koreaexim.go.kr/site/program/financial/exchangeJSON?authkey=" +
                apiKey +
                "&searchdate=" +
                yesterdayDate +
                "&data=AP01";

            string todayRate = GetExchangeRate(todayExURL);

            string yesterdayRate = GetExchangeRate(yesterdayExURL);

            if (!string.IsNullOrEmpty(todayRate))
            {
                text_today.Text = $"1$ = {todayRate} \\";
            }

            if (!string.IsNullOrEmpty(yesterdayRate))
            {
                text_yesterday.Text = $"1$ = {yesterdayRate} \\";
            }
        }

        private string GetExchangeRate(string url)
        {
            try
            {
                HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(url);
                hwr.ContentType = "application/json";

                using (HttpWebResponse hwrResult = hwr.GetResponse() as HttpWebResponse)
                {
                    Stream sr = hwrResult.GetResponseStream();
                    using (StreamReader srd = new StreamReader(sr))
                    {
                        string strResult = srd.ReadToEnd();

                        var exchangeRates = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ExchangeRate>>(strResult);
                        var usdRate = exchangeRates.FirstOrDefault(rate => rate.cur_unit == "USD")?.deal_bas_r;

                        return usdRate; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터 가져오기 오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public class ExchangeRate
        {
            public int result { get; set; }
            public string cur_unit { get; set; }
            public string ttb { get; set; }
            public string tts { get; set; }
            public string deal_bas_r { get; set; }
            public string bkpr { get; set; }
            public string cur_nm { get; set; }
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {

            try
            {
                string url = "https://finance.naver.com/news/news_list.naver?mode=LSS3D&section_id=101&section_id2=258&section_id3=429";
                List<string> headlines = GetStockHeadlines(url);

                if (headlines != null)
                {
                    string[] articles = headlines.Take(10).ToArray();

                    this.Invoke((MethodInvoker)delegate
                    {
                        text_article1.Text = articles.Length > 0 ? articles[0] : "";
                        text_article2.Text = articles.Length > 1 ? articles[1] : "";
                        text_article3.Text = articles.Length > 2 ? articles[2] : "";
                        text_article4.Text = articles.Length > 3 ? articles[3] : "";
                        text_article5.Text = articles.Length > 4 ? articles[4] : "";
                        text_article6.Text = articles.Length > 5 ? articles[5] : "";
                        text_article7.Text = articles.Length > 6 ? articles[6] : "";
                        text_article8.Text = articles.Length > 7 ? articles[7] : "";
                        text_article9.Text = articles.Length > 8 ? articles[8] : "";
                        text_article10.Text = articles.Length > 9 ? articles[9] : "";
                    });
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        text_article1.Text = "환율과 관련된 기사가 없습니다.";
                    });
                }

                Console.WriteLine("작업이 완료되었습니다.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"예외가 발생했습니다: {ex.Message}");
            }
            

            
        }

        private List<string> GetStockHeadlines(string url)
        {
            try
            {
                List<string> headlines = new List<string>();

                var web = new HtmlWeb();

                var doc = web.Load(url);

                var headlineNodes = doc.DocumentNode.SelectNodes($"//ul[@class='realtimeNewsList']/li/dl/dd/a");

                if (headlineNodes != null)
                {
                    foreach (var headlineNode in headlineNodes)
                    {
                        string decodedText = HttpUtility.HtmlDecode(headlineNode.InnerText.Trim());
                        headlines.Add(decodedText); // 디코딩된 텍스트 추가
                    }
                }
                else
                {
                    return null;
                }
                return headlines;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"예외가 발생했습니다: {ex.Message}");
                return null;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private async void button_ai_ClickAsync(object sender, EventArgs e)
        {
            Form2 loadingForm = new Form2();
            loadingForm.Show();
            this.Enabled = false;

            this.Invoke((MethodInvoker)delegate
            {
                text_ai.Text = "분석 중입니다. 분석 과정은 최대 1분이 걸릴 수 있습니다.";
            });

            string apiKey = "api-key";
            string prompt = $"오늘의 환율 정보: {text_today.Text}\n" +
                $"어제의 환율 정보: {text_yesterday.Text}\n" +
                "오늘의 환율 관련 기사:\n" +
                $"{text_article1.Text}\n" +
                $"{text_article2.Text}\n" +
                $"{text_article3.Text}\n" +
                $"{text_article4.Text}\n" +
                $"{text_article5.Text}\n" +
                $"{text_article6.Text}\n" +
                $"{text_article7.Text}\n" +
                $"{text_article8.Text}\n" +
                $"{text_article9.Text}\n" +
                $"{text_article10.Text}\n\n" +
                "위 데이터를 바탕으로 현재의 환율을 분석하고 미래의 환율을 예측. " +
                "예측을 하는데 있어서 가장 확률이 높은 시나리오를 제시하되 '모르겠다','어렵다'라는 의견은 사용하지 말고 " +
                "엔화, 유로화등은 제외하고 오직 미국달러와의 환율만 분석" +
                "그리고 단답식으로 답변하고 일반적인 상식 범위내에서 너무 간단한 금융지식은 생략하고 너무 길어지지 않도록 작성" +
                "마지막으로 마지막 줄에는 1줄의 간단한 요약 작성";


            var requestContent = new
            {
                model = "gpt-4",
                messages = new[]
                {
                    new {role = "system", content = "당신은 금융분석가입니다."},
                    new {role = "user", content = prompt}
                }
            };

            var content = new StringContent(JsonConvert.SerializeObject(requestContent), Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                dynamic responseObject = JsonConvert.DeserializeObject(responseString);
                
                this.Invoke((MethodInvoker)delegate
                {
                    text_ai.Text = responseObject.choices[0].message.content;
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    text_ai.Text = "분석 과정에서 문제가 발생하였습니다. 다시 시도해주세요.";
                });
            }

            this.Enabled = true;
            loadingForm.Close();

        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}
