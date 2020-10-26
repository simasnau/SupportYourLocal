namespace Trust_Your_Locals
{
    partial class PlaceOrderForm
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
            this.orderButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.quantityBox = new System.Windows.Forms.TextBox();
            this.timeBox = new System.Windows.Forms.TextBox();
            this.timeBoxHint = new System.Windows.Forms.Label();
            this.quantityBoxHint = new System.Windows.Forms.Label();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // orderButton
            // 
            this.orderButton.Location = new System.Drawing.Point(109, 199);
            this.orderButton.Name = "orderButton";
            this.orderButton.Size = new System.Drawing.Size(132, 46);
            this.orderButton.TabIndex = 0;
            this.orderButton.Text = "Place Order";
            this.orderButton.UseVisualStyleBackColor = true;
            this.orderButton.Click += new System.EventHandler(this.placeOrder);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(367, 199);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(107, 46);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += CancelButton_Click;
            // 
            // quantityBox
            // 
            this.quantityBox.Location = new System.Drawing.Point(265, 48);
            this.quantityBox.Name = "quantityBox";
            this.quantityBox.Size = new System.Drawing.Size(100, 26);
            this.quantityBox.TabIndex = 2;
            // 
            // timeBox
            // 
            this.timeBox.Location = new System.Drawing.Point(265, 126);
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(100, 26);
            this.timeBox.TabIndex = 3;
            // 
            // timeBoxHint
            // 
            this.timeBoxHint.AutoSize = true;
            this.timeBoxHint.Location = new System.Drawing.Point(390, 129);
            this.timeBoxHint.Name = "timeBoxHint";
            this.timeBoxHint.Size = new System.Drawing.Size(73, 20);
            this.timeBoxHint.TabIndex = 4;
            this.timeBoxHint.Text = "(HH:mm)";
            // 
            // quantityBoxHint
            // 
            this.quantityBoxHint.AutoSize = true;
            this.quantityBoxHint.Location = new System.Drawing.Point(394, 53);
            this.quantityBoxHint.Name = "quantityBoxHint";
            this.quantityBoxHint.Size = new System.Drawing.Size(36, 20);
            this.quantityBoxHint.TabIndex = 5;
            this.quantityBoxHint.Text = "(kg)";
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Location = new System.Drawing.Point(129, 48);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(72, 20);
            this.quantityLabel.TabIndex = 6;
            this.quantityLabel.Text = "Quantity:";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(133, 124);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(95, 20);
            this.timeLabel.TabIndex = 7;
            this.timeLabel.Text = "Pick-up time";
            // 
            // PlaceOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 266);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.quantityLabel);
            this.Controls.Add(this.quantityBoxHint);
            this.Controls.Add(this.timeBoxHint);
            this.Controls.Add(this.timeBox);
            this.Controls.Add(this.quantityBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.orderButton);
            this.Name = "PlaceOrderForm";
            this.Text = "PlaceOrderForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Button orderButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox quantityBox;
        private System.Windows.Forms.TextBox timeBox;
        private System.Windows.Forms.Label timeBoxHint;
        private System.Windows.Forms.Label quantityBoxHint;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.Label timeLabel;
    }
}