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

namespace ExchangeRateService
{

    

    public partial class Form1 : Form
    {

        public Form1()
        {

            InitializeComponent();
            //LoadExchangeRates();
            //LoadArticles();
            System.Timers.Timer timer;
            timer = new System.Timers.Timer(10000);
            timer.Elapsed += OnTimerElapsed;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void LoadExchangeRates()
        {
            string apiKey = "API-KEY";

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

                        // JSON 데이터 파싱
                        var exchangeRates = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ExchangeRate>>(strResult);
                        var usdRate = exchangeRates.FirstOrDefault(rate => rate.cur_unit == "USD")?.deal_bas_r;

                        return usdRate; // USD의 deal_bas_r 값 반환
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

        private void LoadArticles()
        {



            // 크롤링한 기사 데이터를 예시로 배열에 저장
            string[] articles = new string[]
            {
                "환율 급등, 경제에 미치는 영향은?",
                "오늘의 주요 경제 뉴스",
                "환율 하락, 수출 기업의 반응",
                "외환 시장의 변동성 증가",
                "달러 강세 지속 전망",
                "유로화 약세, 원화에 미치는 영향",
                "금리 인상과 환율의 관계",
                "경제 전문가들의 환율 예측",
                "환율 변동으로 인한 투자 전략",
                "오늘의 외환 시장 브리핑"
            };

            // 각 텍스트박스에 기사 데이터 바인딩
            text_article1.Text = articles[0];
            text_article2.Text = articles[1];
            text_article3.Text = articles[2];
            text_article4.Text = articles[3];
            text_article5.Text = articles[4];
            text_article6.Text = articles[5];
            text_article7.Text = articles[6];
            text_article8.Text = articles[7];
            text_article9.Text = articles[8];
            text_article10.Text = articles[9];
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                

                string keyword = "환율";
                string url = "https://finance.naver.com/news/mainnews.nhn";
                List<string> headlines = GetStockHeadlines(url, keyword);

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

        private List<string> GetStockHeadlines(string url, string keyword)
        {
            try
            {
                List<string> headlines = new List<string>();

                var web = new HtmlWeb();

                var doc = web.Load(url);

                var headlineNodes = doc.DocumentNode.SelectNodes($"//ul[@class='newsList']/li/dl/dd/a[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{keyword}')]");

                if (headlineNodes != null)
                {
                    foreach (var headlineNode in headlineNodes)
                    {
                        headlines.Add(headlineNode.InnerText.Trim());
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
            // GPT API 호출 예제 (실제 API 키와 URL로 대체해야 함)
            string apiKey = "api-key";
            string prompt = "블라블라";

            string analysisResult = await CallGptApi(apiKey, prompt);

            // 분석 결과를 텍스트박스에 표시
            text_ai.Text = analysisResult;
        }

        private async Task<string> CallGptApi(string apiKey, string prompt)
        {
            return "분석한 내용";
        }
    }
}
