namespace socks
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_hostname = new System.Windows.Forms.TextBox();
            this.nud_sendport = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nud_iterations = new System.Windows.Forms.NumericUpDown();
            this.tb_message = new System.Windows.Forms.TextBox();
            this.rtb_output = new System.Windows.Forms.RichTextBox();
            this.b_send = new System.Windows.Forms.Button();
            this.nud_receiveport = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.b_listen = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_sendport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_iterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_receiveport)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_hostname
            // 
            this.tb_hostname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_hostname.Location = new System.Drawing.Point(147, 12);
            this.tb_hostname.Name = "tb_hostname";
            this.tb_hostname.Size = new System.Drawing.Size(291, 29);
            this.tb_hostname.TabIndex = 0;
            this.tb_hostname.Text = "DESKTOP-BIFDJ5U";
            // 
            // nud_sendport
            // 
            this.nud_sendport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_sendport.Location = new System.Drawing.Point(147, 60);
            this.nud_sendport.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nud_sendport.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nud_sendport.Name = "nud_sendport";
            this.nud_sendport.Size = new System.Drawing.Size(166, 29);
            this.nud_sendport.TabIndex = 1;
            this.nud_sendport.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Host name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Iterations:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(49, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Message:";
            // 
            // nud_iterations
            // 
            this.nud_iterations.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_iterations.Location = new System.Drawing.Point(147, 130);
            this.nud_iterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_iterations.Name = "nud_iterations";
            this.nud_iterations.Size = new System.Drawing.Size(166, 29);
            this.nud_iterations.TabIndex = 5;
            this.nud_iterations.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tb_message
            // 
            this.tb_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_message.Location = new System.Drawing.Point(147, 95);
            this.tb_message.Name = "tb_message";
            this.tb_message.Size = new System.Drawing.Size(353, 29);
            this.tb_message.TabIndex = 4;
            // 
            // rtb_output
            // 
            this.rtb_output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_output.Location = new System.Drawing.Point(10, 165);
            this.rtb_output.Name = "rtb_output";
            this.rtb_output.Size = new System.Drawing.Size(580, 231);
            this.rtb_output.TabIndex = 8;
            this.rtb_output.Text = "";
            // 
            // b_send
            // 
            this.b_send.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_send.Location = new System.Drawing.Point(516, 98);
            this.b_send.Name = "b_send";
            this.b_send.Size = new System.Drawing.Size(75, 23);
            this.b_send.TabIndex = 9;
            this.b_send.Text = "Send";
            this.b_send.UseVisualStyleBackColor = true;
            this.b_send.Click += new System.EventHandler(this.B_send_Click);
            // 
            // nud_receiveport
            // 
            this.nud_receiveport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_receiveport.Location = new System.Drawing.Point(334, 60);
            this.nud_receiveport.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nud_receiveport.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nud_receiveport.Name = "nud_receiveport";
            this.nud_receiveport.Size = new System.Drawing.Size(166, 29);
            this.nud_receiveport.TabIndex = 10;
            this.nud_receiveport.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nud_receiveport.ValueChanged += new System.EventHandler(this.Nud_receiveport_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Send";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(391, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Receive";
            // 
            // b_listen
            // 
            this.b_listen.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.b_listen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_listen.Location = new System.Drawing.Point(264, 402);
            this.b_listen.Name = "b_listen";
            this.b_listen.Size = new System.Drawing.Size(75, 23);
            this.b_listen.TabIndex = 13;
            this.b_listen.Text = "Listen";
            this.b_listen.UseVisualStyleBackColor = true;
            this.b_listen.Click += new System.EventHandler(this.B_listen_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(517, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Package";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 430);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.b_listen);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nud_receiveport);
            this.Controls.Add(this.b_send);
            this.Controls.Add(this.rtb_output);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nud_iterations);
            this.Controls.Add(this.tb_message);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nud_sendport);
            this.Controls.Add(this.tb_hostname);
            this.MinimumSize = new System.Drawing.Size(620, 400);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nud_sendport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_iterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_receiveport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_hostname;
        private System.Windows.Forms.NumericUpDown nud_sendport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nud_iterations;
        private System.Windows.Forms.TextBox tb_message;
        private System.Windows.Forms.RichTextBox rtb_output;
        private System.Windows.Forms.Button b_send;
        private System.Windows.Forms.NumericUpDown nud_receiveport;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button b_listen;
        private System.Windows.Forms.Button button1;
    }
}

