using System;
using System.Collections.Generic;
using ICT13580044FinalA.Models;
using Xamarin.Forms;

namespace ICT13580044FinalA
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			newButton.Clicked += NewButton_Clicked;


		}

		void NewButton_Clicked(object sender, EventArgs e)
		{
            Navigation.PushModalAsync(new ProfileNewPage());
		}
		protected override void OnAppearing()
		{
			LoadData();
		}
		void LoadData()
		{
			productListView.ItemsSource = App.DbHelpers.GetProducts();
		}

		void Edit_Clicked(object sender, System.EventArgs e)
		{

			var button = sender as MenuItem;
            var profile = button.CommandParameter as profile;
            Navigation.PushModalAsync(new ProfileNewPage(profile));
		}
		async void Delete_Clicked(object sender, System.EventArgs e)
		{
			var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการลบใช่หรือไม่", "ใช่", "ไม่ใช่");
			if (isOk)
			{
				var button = sender as MenuItem;
                var profile = button.CommandParameter as profile;
				App.DbHelpers.DeleteProduct(product);

				await DisplayAlert("ลบสำเร็จ", "ลบข้อมูลสินค้าเรียบร้อย", "ตกลง");
				LoadData();
			}
		}
	}
}