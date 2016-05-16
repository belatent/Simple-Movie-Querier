namespace A2Q3
{
    partial class DetailPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailPage));
            this.submit = new System.Windows.Forms.Button();
            this.commentAdd = new System.Windows.Forms.TextBox();
            this.addComment = new System.Windows.Forms.Label();
            this.comment = new System.Windows.Forms.Label();
            this.rating = new System.Windows.Forms.Label();
            this.watch = new System.Windows.Forms.Button();
            this.share = new System.Windows.Forms.Button();
            this.addwl = new System.Windows.Forms.Button();
            this.genre = new System.Windows.Forms.Label();
            this.cert = new System.Windows.Forms.Label();
            this.director = new System.Windows.Forms.Label();
            this.length = new System.Windows.Forms.Label();
            this.year = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.cast = new System.Windows.Forms.Label();
            this.commentShow = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // submit
            // 
            this.submit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.submit.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submit.Location = new System.Drawing.Point(11, 478);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(424, 29);
            this.submit.TabIndex = 37;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = false;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // commentAdd
            // 
            this.commentAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.commentAdd.Location = new System.Drawing.Point(11, 358);
            this.commentAdd.Multiline = true;
            this.commentAdd.Name = "commentAdd";
            this.commentAdd.Size = new System.Drawing.Size(424, 113);
            this.commentAdd.TabIndex = 34;
            // 
            // addComment
            // 
            this.addComment.Font = new System.Drawing.Font("Source Sans Pro Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addComment.Location = new System.Drawing.Point(6, 334);
            this.addComment.Name = "addComment";
            this.addComment.Size = new System.Drawing.Size(165, 21);
            this.addComment.TabIndex = 33;
            this.addComment.Text = "Add a common :";
            // 
            // comment
            // 
            this.comment.Font = new System.Drawing.Font("Source Sans Pro Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comment.Location = new System.Drawing.Point(6, 10);
            this.comment.Name = "comment";
            this.comment.Size = new System.Drawing.Size(429, 21);
            this.comment.TabIndex = 32;
            this.comment.Text = "Comment :";
            // 
            // rating
            // 
            this.rating.Font = new System.Drawing.Font("Prestige Elite Std", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rating.Location = new System.Drawing.Point(13, 162);
            this.rating.Name = "rating";
            this.rating.Size = new System.Drawing.Size(429, 26);
            this.rating.TabIndex = 31;
            this.rating.Text = "Rating : ";
            // 
            // watch
            // 
            this.watch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.watch.Font = new System.Drawing.Font("Trajan Pro 3", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.watch.Location = new System.Drawing.Point(222, 462);
            this.watch.Name = "watch";
            this.watch.Size = new System.Drawing.Size(210, 50);
            this.watch.TabIndex = 29;
            this.watch.Text = "Buy";
            this.watch.UseVisualStyleBackColor = false;
            this.watch.Click += new System.EventHandler(this.watch_Click);
            // 
            // share
            // 
            this.share.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.share.Font = new System.Drawing.Font("Trajan Pro 3", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.share.Location = new System.Drawing.Point(12, 462);
            this.share.Name = "share";
            this.share.Size = new System.Drawing.Size(210, 50);
            this.share.TabIndex = 28;
            this.share.Text = "Share";
            this.share.UseVisualStyleBackColor = false;
            this.share.Click += new System.EventHandler(this.share_Click);
            // 
            // addwl
            // 
            this.addwl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.addwl.Font = new System.Drawing.Font("Trajan Pro 3", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addwl.Location = new System.Drawing.Point(12, 406);
            this.addwl.Name = "addwl";
            this.addwl.Size = new System.Drawing.Size(420, 50);
            this.addwl.TabIndex = 27;
            this.addwl.Text = "Add to watch list";
            this.addwl.UseVisualStyleBackColor = false;
            this.addwl.Click += new System.EventHandler(this.addwl_Click);
            // 
            // genre
            // 
            this.genre.Font = new System.Drawing.Font("Prestige Elite Std", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genre.Location = new System.Drawing.Point(13, 233);
            this.genre.Name = "genre";
            this.genre.Size = new System.Drawing.Size(157, 170);
            this.genre.TabIndex = 26;
            this.genre.Text = "Genre:";
            // 
            // cert
            // 
            this.cert.Font = new System.Drawing.Font("Prestige Elite Std", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cert.Location = new System.Drawing.Point(13, 197);
            this.cert.Name = "cert";
            this.cert.Size = new System.Drawing.Size(424, 21);
            this.cert.TabIndex = 25;
            this.cert.Text = "Certification : ";
            // 
            // director
            // 
            this.director.Font = new System.Drawing.Font("Prestige Elite Std", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.director.Location = new System.Drawing.Point(13, 128);
            this.director.Name = "director";
            this.director.Size = new System.Drawing.Size(424, 21);
            this.director.TabIndex = 24;
            this.director.Text = "Director : ";
            // 
            // length
            // 
            this.length.Font = new System.Drawing.Font("Prestige Elite Std", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.length.Location = new System.Drawing.Point(13, 90);
            this.length.Name = "length";
            this.length.Size = new System.Drawing.Size(424, 25);
            this.length.TabIndex = 23;
            this.length.Text = "Length : ";
            // 
            // year
            // 
            this.year.Font = new System.Drawing.Font("Prestige Elite Std", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.year.Location = new System.Drawing.Point(13, 55);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(426, 21);
            this.year.TabIndex = 22;
            this.year.Text = "Release Year : ";
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Trajan Pro 3", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(7, 13);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(425, 42);
            this.title.TabIndex = 19;
            this.title.Text = "Name";
            // 
            // cast
            // 
            this.cast.Font = new System.Drawing.Font("Prestige Elite Std", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cast.Location = new System.Drawing.Point(176, 233);
            this.cast.Name = "cast";
            this.cast.Size = new System.Drawing.Size(256, 170);
            this.cast.TabIndex = 38;
            this.cast.Text = "Cast:";
            // 
            // commentShow
            // 
            this.commentShow.Location = new System.Drawing.Point(11, 34);
            this.commentShow.Multiline = true;
            this.commentShow.Name = "commentShow";
            this.commentShow.Size = new System.Drawing.Size(424, 297);
            this.commentShow.TabIndex = 39;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.commentShow);
            this.panel1.Controls.Add(this.submit);
            this.panel1.Controls.Add(this.commentAdd);
            this.panel1.Controls.Add(this.addComment);
            this.panel1.Controls.Add(this.comment);
            this.panel1.Location = new System.Drawing.Point(443, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 521);
            this.panel1.TabIndex = 40;
            // 
            // DetailPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 519);
            this.Controls.Add(this.cast);
            this.Controls.Add(this.watch);
            this.Controls.Add(this.share);
            this.Controls.Add(this.addwl);
            this.Controls.Add(this.genre);
            this.Controls.Add(this.rating);
            this.Controls.Add(this.cert);
            this.Controls.Add(this.director);
            this.Controls.Add(this.length);
            this.Controls.Add(this.year);
            this.Controls.Add(this.title);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(904, 558);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(904, 558);
            this.Name = "DetailPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DetailPage";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.TextBox commentAdd;
        private System.Windows.Forms.Label addComment;
        private System.Windows.Forms.Label comment;
        private System.Windows.Forms.Label rating;
        private System.Windows.Forms.Button watch;
        private System.Windows.Forms.Button share;
        private System.Windows.Forms.Button addwl;
        private System.Windows.Forms.Label genre;
        private System.Windows.Forms.Label cert;
        private System.Windows.Forms.Label director;
        private System.Windows.Forms.Label length;
        private System.Windows.Forms.Label year;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label cast;
        private System.Windows.Forms.TextBox commentShow;
        private System.Windows.Forms.Panel panel1;
    }
}