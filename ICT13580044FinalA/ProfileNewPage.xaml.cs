using System;
using System.Collections.Generic;
using ICT13580044FinalA.Models;
using Xamarin.Forms;

namespace ICT13580044FinalA
{
    public partial class ProfileNewPage : ContentPage
    {
        Profile profile;

        public ProfileNewPage(Profile profile = null)
        {
            InitializeComponent();

            this.profile = profile;

            titleLabel.Text = profile == null ? "กรอกข้อมูล" : "แก้ไขข้อมูล";

            saveButton.Clicked += SaveButton_Clicked;
            cancelButton.Clicked += CancelButton_Clicked;

            sexPicker.Items.Add("ชาย");
            sexPicker.Items.Add("หญิง");


			zonePicker.Items.Add("โปรแกรมเมอร์");
            zonePicker.Items.Add("การตลาด");
            zonePicker.Items.Add("นักบัญชี");

            statusPicker.Items.Add("โสด");
            statusPicker.Items.Add("แต่งงานแล้ว");
            statusPicker.Items.Add("หย่าร้าง");

            if (profile != null)
            {
                nameEntry.Text = profile.Name;
                surEntry.Text = profile.Sur;
                ageEntry.Text = profile.Age.ToString();
                sexPicker.SelectedItem = profile.Sex;
                zonePicker.SelectedItem = profile.Zone;
                telEntry.Text = profile.Tel.ToString();
                mailEntry.Text = profile.Mail.ToString();
                addressEditor.Text = profile.Address;
                statusPicker.SelectedItem = profile.Status;
                childEntry.Text = profile.Child.ToString();
                salaryEntry.Text = profile.Salary.ToString();
            }
		}

        async void SaveButton_Clicked(object sender, EventArgs e)
        {
			var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการบันทึกใช่หรือไม่", "ใช่", "ไม่ใช่");
			if (isOk)
			{
                if (profile == null)
				{

                    var profile = new Profile();
                    profile.Name = nameEntry.Text;
                    profile.Sur = surEntry.Text;
                    profile.Age = int.Parse(ageEntry.Text);
                    profile.Sex = sexPicker.SelectedItem.ToString();
                    profile.Zone = zonePicker.SelectedItem.ToString();
                    profile.Tel = int.Parse(telEntry.Text);
                    profile.Mail = mailEntry.ToString();

                    var id = App.DbHelper.AddProduct(profile);
					await DisplayAlert("บันทึกสำเร็จ", "รหัสสินค้าของท่านคือ#" + id, "ตกลง");

				}
				else
				{
					product.Name = nameEntry.Text;
					product.Decription = descriptionEditor.Text;
					product.Cateory = categoryPicker.SelectedItem.ToString();
					product.ProductPrice = decimal.Parse(productPriceEntry.Text);
					product.SellPrice = decimal.Parse(sellPriceEntry.Text);
					product.Stock = int.Parse(stockEntry.Text);

					var id = App.DbHelper.UpdateProduct(product);
					await DisplayAlert("บันทึกสำเร็จ", "แก้ไขข้อมูลสินค้าเรียบร้อย" + id, "ตกลง");
				}
				await Navigation.PopModalAsync();
			}
		}
		void CancelButton_Clicked(object sender, EventArgs e)
		{
			Navigation.PopModalAsync();
		}
	}
}