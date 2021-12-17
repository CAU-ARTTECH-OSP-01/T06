using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


// git 업로드용
namespace OSP_project02
{

    public partial class MainPage : ContentPage
    {
        INotificationManager notificationManager;
        int notificationNumber1 = 0;
        int notificationNumber2 = 0;
        int notificationNumber3 = 0;

        public MainPage()
        {
            // 알림 생성
            InitializeComponent();

            notificationManager = DependencyService.Get<INotificationManager>();
            notificationManager.NotificationReceived += (sender, eventArgs) =>
            {
                var evtData = (NotificationEventArgs)eventArgs;
                ShowNotification(evtData.Title, evtData.Message);
            };
        }

        // 30분 사용알림
        void OnScheduleClick1(object sender, EventArgs e)
        {
            for (int i = 1800; i <= 3600; i += 1800)
            {
                notificationNumber1 += 30;
                string title1 = $"Screen time {notificationNumber1} minute";
                string message1 = $"You have used your phone for {notificationNumber1} minutes!";
                notificationManager.SendNotification(title1, message1, DateTime.Now.AddSeconds(i));
            }
        }

        // 1시간 사용알림
        void OnScheduleClick2(object sender, EventArgs e)
        {
            for (int i = 3600; i <= 7200; i += 3600)
            {
                notificationNumber2++;
                string title2 = $"Screen time {notificationNumber2} hour";
                string message2 = $"You have used your phone for {notificationNumber2} hour(s)!";
                notificationManager.SendNotification(title2, message2, DateTime.Now.AddSeconds(i));
            }
        }
        // 2시간 사용알림
        void OnScheduleClick3(object sender, EventArgs e)
        {
            for (int i = 7200; i <= 14400; i += 7200)
            {
                notificationNumber3 += 2;
                string title2 = $"Screen time {notificationNumber2} hour";
                string message2 = $"You have used your phone for {notificationNumber2} hour(s)!";
                notificationManager.SendNotification(title2, message2, DateTime.Now.AddSeconds(i));
            }
        }

        //알림을 누르면 나오는 메시지
        void ShowNotification(string title, string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                // 눈 운동 추천
                var image1 = new Image
                {
                    Source = "eye_exercise.jpg",
                    WidthRequest = 300,
                    HeightRequest = 450,
                };

                var msg1 = new Label()
                {
                    Text = $"{title}\n{message}\nHow about some eye exercise?",
                    TextColor = Color.White,
                    FontSize = 15
                };
                stackLayout.Children.Add(msg1);
                stackLayout.Children.Add(image1);
            });
        }
        void ShowNotification2(string title, string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {

                // 활동적인 일 추천
                var image2 = new Image
                {
                    Source = "Activity4.jpg",
                    WidthRequest = 320,
                    HeightRequest = 180,
                };

                var msg2 = new Label()
                {
                    Text = $"\n{title}\n{message}\nHow about some physical activity?",
                    TextColor = Color.White,
                    FontSize = 15
                };
                stackLayout.Children.Add(msg2);
                stackLayout.Children.Add(image2);
            });
        }
    }
}

