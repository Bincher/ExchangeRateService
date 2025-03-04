namespace ExchangeRateService
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.text_today = new System.Windows.Forms.TextBox();
            this.text_yesterday = new System.Windows.Forms.TextBox();
            this.label_today = new System.Windows.Forms.Label();
            this.label_yesterday = new System.Windows.Forms.Label();
            this.text_article2 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.text_article4 = new System.Windows.Forms.TextBox();
            this.text_article6 = new System.Windows.Forms.TextBox();
            this.text_article5 = new System.Windows.Forms.TextBox();
            this.text_article7 = new System.Windows.Forms.TextBox();
            this.text_article3 = new System.Windows.Forms.TextBox();
            this.text_article8 = new System.Windows.Forms.TextBox();
            this.text_article9 = new System.Windows.Forms.TextBox();
            this.text_article1 = new System.Windows.Forms.TextBox();
            this.label_article = new System.Windows.Forms.Label();
            this.text_article10 = new System.Windows.Forms.TextBox();
            this.label_ai = new System.Windows.Forms.Label();
            this.text_ai = new System.Windows.Forms.TextBox();
            this.button_ai = new System.Windows.Forms.Button();
            this.label_title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // text_today
            // 
            this.text_today.Location = new System.Drawing.Point(108, 60);
            this.text_today.Name = "text_today";
            this.text_today.ReadOnly = true;
            this.text_today.Size = new System.Drawing.Size(265, 25);
            this.text_today.TabIndex = 0;
            // 
            // text_yesterday
            // 
            this.text_yesterday.Location = new System.Drawing.Point(108, 95);
            this.text_yesterday.Name = "text_yesterday";
            this.text_yesterday.ReadOnly = true;
            this.text_yesterday.Size = new System.Drawing.Size(265, 25);
            this.text_yesterday.TabIndex = 1;
            // 
            // label_today
            // 
            this.label_today.AutoSize = true;
            this.label_today.Location = new System.Drawing.Point(12, 63);
            this.label_today.Name = "label_today";
            this.label_today.Size = new System.Drawing.Size(72, 15);
            this.label_today.TabIndex = 2;
            this.label_today.Text = "현재 환율";
            this.label_today.Click += new System.EventHandler(this.label1_Click);
            // 
            // label_yesterday
            // 
            this.label_yesterday.AutoSize = true;
            this.label_yesterday.Location = new System.Drawing.Point(12, 98);
            this.label_yesterday.Name = "label_yesterday";
            this.label_yesterday.Size = new System.Drawing.Size(72, 15);
            this.label_yesterday.TabIndex = 3;
            this.label_yesterday.Text = "어제 환율";
            // 
            // text_article2
            // 
            this.text_article2.Location = new System.Drawing.Point(12, 182);
            this.text_article2.Name = "text_article2";
            this.text_article2.ReadOnly = true;
            this.text_article2.Size = new System.Drawing.Size(763, 25);
            this.text_article2.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(15, 213);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(760, 25);
            this.textBox2.TabIndex = 5;
            // 
            // text_article4
            // 
            this.text_article4.Location = new System.Drawing.Point(15, 244);
            this.text_article4.Name = "text_article4";
            this.text_article4.ReadOnly = true;
            this.text_article4.Size = new System.Drawing.Size(760, 25);
            this.text_article4.TabIndex = 6;
            // 
            // text_article6
            // 
            this.text_article6.Location = new System.Drawing.Point(15, 306);
            this.text_article6.Name = "text_article6";
            this.text_article6.ReadOnly = true;
            this.text_article6.Size = new System.Drawing.Size(760, 25);
            this.text_article6.TabIndex = 7;
            // 
            // text_article5
            // 
            this.text_article5.Location = new System.Drawing.Point(15, 275);
            this.text_article5.Name = "text_article5";
            this.text_article5.ReadOnly = true;
            this.text_article5.Size = new System.Drawing.Size(760, 25);
            this.text_article5.TabIndex = 8;
            // 
            // text_article7
            // 
            this.text_article7.Location = new System.Drawing.Point(15, 337);
            this.text_article7.Name = "text_article7";
            this.text_article7.ReadOnly = true;
            this.text_article7.Size = new System.Drawing.Size(760, 25);
            this.text_article7.TabIndex = 9;
            // 
            // text_article3
            // 
            this.text_article3.Location = new System.Drawing.Point(12, 213);
            this.text_article3.Name = "text_article3";
            this.text_article3.ReadOnly = true;
            this.text_article3.Size = new System.Drawing.Size(763, 25);
            this.text_article3.TabIndex = 10;
            // 
            // text_article8
            // 
            this.text_article8.Location = new System.Drawing.Point(15, 368);
            this.text_article8.Name = "text_article8";
            this.text_article8.ReadOnly = true;
            this.text_article8.Size = new System.Drawing.Size(760, 25);
            this.text_article8.TabIndex = 11;
            // 
            // text_article9
            // 
            this.text_article9.Location = new System.Drawing.Point(15, 399);
            this.text_article9.Name = "text_article9";
            this.text_article9.ReadOnly = true;
            this.text_article9.Size = new System.Drawing.Size(760, 25);
            this.text_article9.TabIndex = 12;
            // 
            // text_article1
            // 
            this.text_article1.Location = new System.Drawing.Point(12, 151);
            this.text_article1.Name = "text_article1";
            this.text_article1.ReadOnly = true;
            this.text_article1.Size = new System.Drawing.Size(763, 25);
            this.text_article1.TabIndex = 13;
            this.text_article1.Text = "환율 관련 기사를 가져오고 있습니다. 최대 1분이 걸릴 수 있습니다.";
            // 
            // label_article
            // 
            this.label_article.AutoSize = true;
            this.label_article.Location = new System.Drawing.Point(326, 133);
            this.label_article.Name = "label_article";
            this.label_article.Size = new System.Drawing.Size(142, 15);
            this.label_article.TabIndex = 14;
            this.label_article.Text = "오늘 환율 관련 뉴스";
            this.label_article.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // text_article10
            // 
            this.text_article10.Location = new System.Drawing.Point(12, 430);
            this.text_article10.Name = "text_article10";
            this.text_article10.ReadOnly = true;
            this.text_article10.Size = new System.Drawing.Size(763, 25);
            this.text_article10.TabIndex = 15;
            // 
            // label_ai
            // 
            this.label_ai.AutoSize = true;
            this.label_ai.Location = new System.Drawing.Point(411, 66);
            this.label_ai.Name = "label_ai";
            this.label_ai.Size = new System.Drawing.Size(54, 15);
            this.label_ai.TabIndex = 17;
            this.label_ai.Text = "AI 분석";
            this.label_ai.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // text_ai
            // 
            this.text_ai.Location = new System.Drawing.Point(414, 95);
            this.text_ai.Name = "text_ai";
            this.text_ai.ReadOnly = true;
            this.text_ai.Size = new System.Drawing.Size(361, 25);
            this.text_ai.TabIndex = 18;
            // 
            // button_ai
            // 
            this.button_ai.Location = new System.Drawing.Point(480, 60);
            this.button_ai.Name = "button_ai";
            this.button_ai.Size = new System.Drawing.Size(75, 23);
            this.button_ai.TabIndex = 19;
            this.button_ai.Text = "분석하기";
            this.button_ai.UseVisualStyleBackColor = true;
            this.button_ai.Click += new System.EventHandler(this.button_ai_ClickAsync);
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Location = new System.Drawing.Point(326, 18);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(122, 15);
            this.label_title.TabIndex = 20;
            this.label_title.Text = "환율 분석 서비스";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 462);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.button_ai);
            this.Controls.Add(this.text_ai);
            this.Controls.Add(this.label_ai);
            this.Controls.Add(this.text_article10);
            this.Controls.Add(this.label_article);
            this.Controls.Add(this.text_article1);
            this.Controls.Add(this.text_article9);
            this.Controls.Add(this.text_article8);
            this.Controls.Add(this.text_article3);
            this.Controls.Add(this.text_article7);
            this.Controls.Add(this.text_article5);
            this.Controls.Add(this.text_article6);
            this.Controls.Add(this.text_article4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.text_article2);
            this.Controls.Add(this.label_yesterday);
            this.Controls.Add(this.label_today);
            this.Controls.Add(this.text_yesterday);
            this.Controls.Add(this.text_today);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text_today;
        private System.Windows.Forms.TextBox text_yesterday;
        private System.Windows.Forms.Label label_today;
        private System.Windows.Forms.Label label_yesterday;
        private System.Windows.Forms.TextBox text_article2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox text_article4;
        private System.Windows.Forms.TextBox text_article6;
        private System.Windows.Forms.TextBox text_article5;
        private System.Windows.Forms.TextBox text_article7;
        private System.Windows.Forms.TextBox text_article3;
        private System.Windows.Forms.TextBox text_article8;
        private System.Windows.Forms.TextBox text_article9;
        private System.Windows.Forms.TextBox text_article1;
        private System.Windows.Forms.Label label_article;
        private System.Windows.Forms.TextBox text_article10;
        private System.Windows.Forms.Label label_ai;
        private System.Windows.Forms.TextBox text_ai;
        private System.Windows.Forms.Button button_ai;
        private System.Windows.Forms.Label label_title;
    }
}

