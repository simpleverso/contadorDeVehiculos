namespace conteoVehiculos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.thresholdedBox = new System.Windows.Forms.PictureBox();
            this.maskedBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmb_fuente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.videoPlayer = new Accord.Controls.VideoSourcePlayer();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.carLabel = new System.Windows.Forms.Label();
            this.cmb_webcams = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.txt_usuario = new System.Windows.Forms.TextBox();
            this.txt_contrasenia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_tamanio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_dils = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_tamanio2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_ers = new System.Windows.Forms.TextBox();
            this.pb_ipcam = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.txt_video = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_puerto = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pb_lprptzanalitica = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_frames = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txt_thr = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdedBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maskedBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ipcam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_lprptzanalitica)).BeginInit();
            this.SuspendLayout();
            // 
            // thresholdedBox
            // 
            this.thresholdedBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.thresholdedBox.Location = new System.Drawing.Point(12, 218);
            this.thresholdedBox.Name = "thresholdedBox";
            this.thresholdedBox.Size = new System.Drawing.Size(152, 139);
            this.thresholdedBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.thresholdedBox.TabIndex = 1;
            this.thresholdedBox.TabStop = false;
            // 
            // maskedBox
            // 
            this.maskedBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.maskedBox.Location = new System.Drawing.Point(170, 218);
            this.maskedBox.Name = "maskedBox";
            this.maskedBox.Size = new System.Drawing.Size(149, 139);
            this.maskedBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.maskedBox.TabIndex = 2;
            this.maskedBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(647, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 49);
            this.button1.TabIndex = 3;
            this.button1.Text = "Comenzar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmb_fuente
            // 
            this.cmb_fuente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_fuente.FormattingEnabled = true;
            this.cmb_fuente.Items.AddRange(new object[] {
            "Archivo de video",
            "WebCam",
            "Camara IP",
            "LPR/PTZ/ANALITICA"});
            this.cmb_fuente.Location = new System.Drawing.Point(735, 12);
            this.cmb_fuente.Name = "cmb_fuente";
            this.cmb_fuente.Size = new System.Drawing.Size(197, 21);
            this.cmb_fuente.TabIndex = 4;
            this.cmb_fuente.SelectedIndexChanged += new System.EventHandler(this.cmb_fuente_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(619, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Seleccione la fuente";
            // 
            // videoPlayer
            // 
            this.videoPlayer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.videoPlayer.Location = new System.Drawing.Point(12, 12);
            this.videoPlayer.Name = "videoPlayer";
            this.videoPlayer.Size = new System.Drawing.Size(190, 151);
            this.videoPlayer.TabIndex = 6;
            this.videoPlayer.Text = "videoSourcePlayer1";
            this.videoPlayer.VideoSource = null;
            this.videoPlayer.NewFrame += new Accord.Controls.VideoSourcePlayer.NewFrameHandler(this.videoPlayer_NewFrame_1);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // carLabel
            // 
            this.carLabel.AutoSize = true;
            this.carLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.carLabel.Location = new System.Drawing.Point(335, 333);
            this.carLabel.Name = "carLabel";
            this.carLabel.Size = new System.Drawing.Size(200, 24);
            this.carLabel.TabIndex = 7;
            this.carLabel.Text = "Cantidad de Vehiculos";
            // 
            // cmb_webcams
            // 
            this.cmb_webcams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_webcams.FormattingEnabled = true;
            this.cmb_webcams.Location = new System.Drawing.Point(735, 84);
            this.cmb_webcams.Name = "cmb_webcams";
            this.cmb_webcams.Size = new System.Drawing.Size(197, 21);
            this.cmb_webcams.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(616, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Seleccionar webcam";
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(735, 109);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(196, 20);
            this.txt_ip.TabIndex = 10;
            this.txt_ip.Text = "http://192.168.0.6:8081";
            this.txt_ip.TextChanged += new System.EventHandler(this.txt_ip_TextChanged);
            // 
            // txt_usuario
            // 
            this.txt_usuario.Location = new System.Drawing.Point(735, 158);
            this.txt_usuario.Name = "txt_usuario";
            this.txt_usuario.PasswordChar = 'X';
            this.txt_usuario.Size = new System.Drawing.Size(196, 20);
            this.txt_usuario.TabIndex = 11;
            // 
            // txt_contrasenia
            // 
            this.txt_contrasenia.Location = new System.Drawing.Point(735, 185);
            this.txt_contrasenia.Name = "txt_contrasenia";
            this.txt_contrasenia.PasswordChar = 'X';
            this.txt_contrasenia.Size = new System.Drawing.Size(196, 20);
            this.txt_contrasenia.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(700, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "IP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(674, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Usuario";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(654, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Contrasenia";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(350, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Tamaño obj";
            // 
            // txt_tamanio
            // 
            this.txt_tamanio.Location = new System.Drawing.Point(416, 229);
            this.txt_tamanio.Name = "txt_tamanio";
            this.txt_tamanio.Size = new System.Drawing.Size(22, 20);
            this.txt_tamanio.TabIndex = 16;
            this.txt_tamanio.Text = "40";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(454, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Dils";
            // 
            // txt_dils
            // 
            this.txt_dils.Location = new System.Drawing.Point(485, 228);
            this.txt_dils.Name = "txt_dils";
            this.txt_dils.Size = new System.Drawing.Size(22, 20);
            this.txt_dils.TabIndex = 18;
            this.txt_dils.Text = "7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(345, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Tamaño filtro";
            // 
            // txt_tamanio2
            // 
            this.txt_tamanio2.Location = new System.Drawing.Point(416, 254);
            this.txt_tamanio2.Name = "txt_tamanio2";
            this.txt_tamanio2.Size = new System.Drawing.Size(22, 20);
            this.txt_tamanio2.TabIndex = 20;
            this.txt_tamanio2.Text = "50";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(456, 257);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Ers";
            // 
            // txt_ers
            // 
            this.txt_ers.Location = new System.Drawing.Point(485, 253);
            this.txt_ers.Name = "txt_ers";
            this.txt_ers.Size = new System.Drawing.Size(22, 20);
            this.txt_ers.TabIndex = 22;
            this.txt_ers.Text = "2";
            // 
            // pb_ipcam
            // 
            this.pb_ipcam.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pb_ipcam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_ipcam.Location = new System.Drawing.Point(208, 12);
            this.pb_ipcam.Name = "pb_ipcam";
            this.pb_ipcam.Size = new System.Drawing.Size(186, 151);
            this.pb_ipcam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_ipcam.TabIndex = 24;
            this.pb_ipcam.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(857, 55);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_buscar.TabIndex = 25;
            this.btn_buscar.Text = "Buscar...";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_video
            // 
            this.txt_video.Location = new System.Drawing.Point(735, 56);
            this.txt_video.Name = "txt_video";
            this.txt_video.Size = new System.Drawing.Size(120, 20);
            this.txt_video.TabIndex = 26;
            this.txt_video.Text = "./input.mp4";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(602, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Puerto ptz/analitica/lpr";
            // 
            // txt_puerto
            // 
            this.txt_puerto.Location = new System.Drawing.Point(735, 132);
            this.txt_puerto.Name = "txt_puerto";
            this.txt_puerto.Size = new System.Drawing.Size(196, 20);
            this.txt_puerto.TabIndex = 27;
            this.txt_puerto.Text = "554";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(630, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Archivo de video";
            // 
            // pb_lprptzanalitica
            // 
            this.pb_lprptzanalitica.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pb_lprptzanalitica.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_lprptzanalitica.Location = new System.Drawing.Point(400, 12);
            this.pb_lprptzanalitica.Name = "pb_lprptzanalitica";
            this.pb_lprptzanalitica.Size = new System.Drawing.Size(184, 151);
            this.pb_lprptzanalitica.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_lprptzanalitica.TabIndex = 30;
            this.pb_lprptzanalitica.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 170);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "Archivo";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(208, 169);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "IP";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(400, 170);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(126, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "LPR / PTZ / ANALITICA";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 364);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 13);
            this.label15.TabIndex = 34;
            this.label15.Text = "Binario";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(170, 364);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 13);
            this.label16.TabIndex = 35;
            this.label16.Text = "Filtrado";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(810, 247);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 49);
            this.button2.TabIndex = 36;
            this.button2.Text = "Detener";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(387, 286);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 13);
            this.label17.TabIndex = 38;
            this.label17.Text = "Frms";
            // 
            // txt_frames
            // 
            this.txt_frames.Location = new System.Drawing.Point(416, 282);
            this.txt_frames.Name = "txt_frames";
            this.txt_frames.Size = new System.Drawing.Size(22, 20);
            this.txt_frames.TabIndex = 37;
            this.txt_frames.Text = "30";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(456, 283);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(23, 13);
            this.label18.TabIndex = 40;
            this.label18.Text = "Thr";
            // 
            // txt_thr
            // 
            this.txt_thr.Location = new System.Drawing.Point(485, 279);
            this.txt_thr.Name = "txt_thr";
            this.txt_thr.Size = new System.Drawing.Size(22, 20);
            this.txt_thr.TabIndex = 39;
            this.txt_thr.Text = "40";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 389);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txt_thr);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txt_frames);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.pb_lprptzanalitica);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_puerto);
            this.Controls.Add(this.txt_video);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.pb_ipcam);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_ers);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_tamanio2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_dils);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_tamanio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_contrasenia);
            this.Controls.Add(this.txt_usuario);
            this.Controls.Add(this.txt_ip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_webcams);
            this.Controls.Add(this.carLabel);
            this.Controls.Add(this.videoPlayer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_fuente);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.maskedBox);
            this.Controls.Add(this.thresholdedBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Sistema de conteo de vehiculos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.thresholdedBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maskedBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ipcam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_lprptzanalitica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox thresholdedBox;
        private System.Windows.Forms.PictureBox maskedBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmb_fuente;
        private System.Windows.Forms.Label label1;
        private Accord.Controls.VideoSourcePlayer videoPlayer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label carLabel;
        private System.Windows.Forms.ComboBox cmb_webcams;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.TextBox txt_usuario;
        private System.Windows.Forms.TextBox txt_contrasenia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_tamanio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_dils;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_tamanio2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_ers;
        private System.Windows.Forms.PictureBox pb_ipcam;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.TextBox txt_video;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_puerto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pb_lprptzanalitica;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_frames;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txt_thr;
    }
}

