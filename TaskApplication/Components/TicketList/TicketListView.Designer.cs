namespace App.UI
{
    partial class TicketListView
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
            this.ticketsGridView = new System.Windows.Forms.DataGridView();
            this.resolveTicketButton = new System.Windows.Forms.Button();
            this.createTicket = new System.Windows.Forms.Button();
            this.editTicketButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ticketsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ticketsGridView
            // 
            this.ticketsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ticketsGridView.Location = new System.Drawing.Point(12, 12);
            this.ticketsGridView.Name = "ticketsGridView";
            this.ticketsGridView.Size = new System.Drawing.Size(969, 388);
            this.ticketsGridView.TabIndex = 0;
            // 
            // resolveTicketButton
            // 
            this.resolveTicketButton.Location = new System.Drawing.Point(12, 406);
            this.resolveTicketButton.Name = "resolveTicketButton";
            this.resolveTicketButton.Size = new System.Drawing.Size(89, 29);
            this.resolveTicketButton.TabIndex = 1;
            this.resolveTicketButton.Text = "Resolve ticket";
            this.resolveTicketButton.UseVisualStyleBackColor = true;
            this.resolveTicketButton.Click += new System.EventHandler(this.resolveTicketButton_Click);
            // 
            // createTicket
            // 
            this.createTicket.Location = new System.Drawing.Point(107, 406);
            this.createTicket.Name = "createTicket";
            this.createTicket.Size = new System.Drawing.Size(89, 29);
            this.createTicket.TabIndex = 2;
            this.createTicket.Text = "Create ticket";
            this.createTicket.UseVisualStyleBackColor = true;
            this.createTicket.Click += new System.EventHandler(this.createTicket_Click);
            // 
            // editTicketButton
            // 
            this.editTicketButton.Location = new System.Drawing.Point(202, 406);
            this.editTicketButton.Name = "editTicketButton";
            this.editTicketButton.Size = new System.Drawing.Size(89, 29);
            this.editTicketButton.TabIndex = 3;
            this.editTicketButton.Text = "Edit ticket";
            this.editTicketButton.UseVisualStyleBackColor = true;
            this.editTicketButton.Click += new System.EventHandler(this.editTicketButton_Click);
            // 
            // TicketListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 547);
            this.Controls.Add(this.editTicketButton);
            this.Controls.Add(this.createTicket);
            this.Controls.Add(this.resolveTicketButton);
            this.Controls.Add(this.ticketsGridView);
            this.Name = "TicketListView";
            this.Text = "TicketForm";
            this.Load += new System.EventHandler(this.TicketListView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ticketsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ticketsGridView;
        private System.Windows.Forms.Button resolveTicketButton;
        private System.Windows.Forms.Button createTicket;
        private System.Windows.Forms.Button editTicketButton;
    }
}