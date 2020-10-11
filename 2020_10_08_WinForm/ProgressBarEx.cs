using System;
using System.Drawing;
using System.Windows.Forms;

namespace _2020_10_08_WinForm
{
    public class ProgressBarEx : ProgressBar
    {
        private SolidBrush brush = null;                    //단색 브러쉬 정의
        public ProgressBarEx() { this.SetStyle(ControlStyles.UserPaint, true); }// 자체적 스타일 적용(운영체제 x)
        protected override void OnPaint(PaintEventArgs e)                       //폼을 그릴 때마다 이미지를 다시 그리게 재정의 됩니다.
        {
            Random r = new Random();
            int R = r.Next(0, byte.MaxValue + 1);
            int G = r.Next(0, byte.MaxValue + 1);
            int B = r.Next(0, byte.MaxValue + 1);

            brush = new SolidBrush(Color.FromArgb(R,G,B));                     //해당 프로그래스 바의 Fore설정 컬러를 가져옴
            Rectangle rec = new Rectangle(0, 0, this.Width, this.Height);   //크기 지정
            if (ProgressBarRenderer.IsSupported)   //비주얼 스타일 진행률 표시 랜더링 //이 클래스의 멤버를 사용할 수 있는지 여부를 확인 하려면 값을 확인할 수 있습니다 
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rec); // 가로로 채워지는 빈 진핼률 표시
            rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;
            rec.Height = rec.Height - 4;
            e.Graphics.FillRectangle(brush, 2, 2, rec.Width, rec.Height); // 지정된 사각형을 채움
        }
    }
}
