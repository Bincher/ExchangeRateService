using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExchangeRateService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadExchangeRates();
            LoadArticles();
            
        }

        private void LoadExchangeRates()
        {
            // 예시 데이터 (실제로는 API 호출로 데이터를 가져와야 함)
            string currentRate = "1 USD = 1300 KRW";
            string yesterdayRate = "1 USD = 1295 KRW";

            // 텍스트박스에 데이터 바인딩
            text_today.Text = $"현재 환율: {currentRate}";
            text_yesterday.Text = $"어제 환율: {yesterdayRate}";
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
