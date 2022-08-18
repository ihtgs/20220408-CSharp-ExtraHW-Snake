using System;
using System.Drawing;
using System.Windows.Forms;

namespace HW_extra_snake
{
    public partial class Form1 : Form
    {
        PictureBox[] picDalala = new PictureBox[19];  //Da Lala picture
        PictureBox[] picSnakeA = new PictureBox[5]; //snakeA Array use .Resize<T> to add the length     *reset
        PictureBox[] picSnakeB = new PictureBox[5]; //snakeB Array use .Resize<T> to add the length     *reset
        PictureBox[] itemLala = new PictureBox[5]; //maxium of items      *reset
        snakeHead snakeA = new snakeHead(2, 1, 5, 500, 40); //head of snakeA:D,P,L,Speed,Size         *reset
        snakeHead snakeB = new snakeHead(1, 1, 5, 500, 40);//head of snakeB             *reset
        int itemNum = 0;  //for implement itemLala      *reset
        int autoResetCount = 12;  //interval = 250ms
        int xM = Cursor.Position.X;  
        int yM = Cursor.Position.Y;
        int gameOver=0;
        bool gameStarted = false;
        bool autoMoveA = true;
        bool autoMoveB = true;

        class snakeHead    //head information
        {
            public int xAxis;
            public int yAxis;
            public int direction;
            public int picture;
            public int length;
            public int speed; //500 ms  
            public int size;
            public snakeHead(int c, int d, int e, int f, int g)
            {
                this.direction = c;
                this.picture = d;
                this.length = e;
                this.speed = f;
                this.size = g;
            }
        }
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < picDalala.Length; i++)  //Implementation picDalala
            {
                picDalala[i] = new PictureBox();
                picDalala[i].Image = Image.FromFile(@"..\..\PICs\large\" + i + ".gif");
            }
            Cursor.Hide();
        }

        private void Start()
        {
            autoMoveA = true;
            autoMoveB = true;
            for (int i = 0; i < itemLala.Length; i++)//implement itemLala
                itemLala[i] = new PictureBox();

            snakeA.xAxis = 280; snakeA.yAxis = 200;
            snakeB.xAxis = Width - 320; snakeB.yAxis = Height - 240;

            for (int i = 0; i < snakeA.length; i++)  //implement snakeA 
            {
                picSnakeA[i] = new PictureBox();
                if (i == 0)
                    picSnakeA[i].Image = picDalala[0].Image; //the head of snakeA
                else
                    picSnakeA[i].Image = picDalala[2].Image; //the body of snakeA
                picSnakeA[i].Location = new Point(snakeA.xAxis, snakeA.yAxis - i * 40);
                picSnakeA[i].SizeMode = PictureBoxSizeMode.AutoSize;
                this.Controls.Add(picSnakeA[i]);
            }

            for (int i = 0; i < snakeB.length; i++)//implement snakeB
            {
                picSnakeB[i] = new PictureBox();
                if (i == 0)
                    picSnakeB[i].Image = picDalala[7].Image;  //the head of snakeB
                else
                    picSnakeB[i].Image = picDalala[1].Image; //the body...
                picSnakeB[i].Location = new Point(snakeB.xAxis, snakeB.yAxis + i * 40);
                picSnakeB[i].SizeMode = PictureBoxSizeMode.AutoSize;
                this.Controls.Add(picSnakeB[i]);
            }
            timer1.Enabled = timer2.Enabled =timer3.Enabled=true; //snake A ,B, item
            timer1.Interval = timer2.Interval=snakeA.speed;//same
        }

        private void SnakeMove(char a)  //parameter char a to distingush snakeA or snakeB
        {//define the first one with snakeA.coordinates 
            if (a == 'A')
            {
                for (int i = snakeA.length - 1; i > 0; i--)  //from the last one
                {
                    picSnakeA[i].Location = picSnakeA[i - 1].Location;
                }
                picSnakeA[0].Location = new Point(snakeA.xAxis, snakeA.yAxis); 
            }
            if (a == 'B')
            {
                for (int i = snakeB.length - 1; i > 0; i--)
                {
                    picSnakeB[i].Location = picSnakeB[i - 1].Location;
                }
                picSnakeB[0].Location = new Point(snakeB.xAxis, snakeB.yAxis);
            }
            ChangePic(); //according to the direction change the picture.
        }

        private void ChangePic() //according to the direction change the picture.
        {   //for snakeA
            for (int i = 1; i < picSnakeA.Length; i++)  // don't change the 1st picture
            {//change the picture to 1 2 3 4(up down left right) without 5 6
                if (picSnakeA[i].Location.X == picSnakeA[i - 1].Location.X && 
                    picSnakeA[i].Location.Y > picSnakeA[i - 1].Location.Y)
                {// Y[i] > Y[i-1]: upward
                    picSnakeA[i].Image = picDalala[1].Image;
                }
                else if (picSnakeA[i].Location.X == picSnakeA[i - 1].Location.X &&
                         picSnakeA[i].Location.Y < picSnakeA[i - 1].Location.Y)
                {// Y[i] < Y[i-1]: downward
                    picSnakeA[i].Image = picDalala[2].Image;
                }
                else if (picSnakeA[i].Location.X > picSnakeA[i - 1].Location.X &&
                         picSnakeA[i].Location.Y == picSnakeA[i - 1].Location.Y)
                {//X[i] > X[i-1] leftward 
                    picSnakeA[i].Image = picDalala[3].Image;
                }
                else if (picSnakeA[i].Location.X < picSnakeA[i - 1].Location.X &&
                         picSnakeA[i].Location.Y == picSnakeA[i - 1].Location.Y)
                {//X[i] < X[i-1] rightward 
                    picSnakeA[i].Image = picDalala[4].Image;
                }
            }

            for (int i = 1; i < picSnakeA.Length - 1; i++)
            {//change the picture to 5 6(actually only 2 pictures are not enough! 
                if (picSnakeA[i + 1].Location.X > picSnakeA[i - 1].Location.X &&
                    picSnakeA[i + 1].Location.Y != picSnakeA[i - 1].Location.Y)
                {
                    picSnakeA[i].Image = picDalala[6].Image;  //sad, no direction 7,8
                }
                else if (picSnakeA[i + 1].Location.X < picSnakeA[i - 1].Location.X &&
                              picSnakeA[i + 1].Location.Y != picSnakeA[i - 1].Location.Y)
                {
                    picSnakeA[i].Image = picDalala[5].Image;
                }
            }

            for (int i = 1; i < picSnakeB.Length; i++)  //for snakeB
            {
                if (picSnakeB[i].Location.X == picSnakeB[i - 1].Location.X &&
                    picSnakeB[i].Location.Y > picSnakeB[i - 1].Location.Y)
                {
                    picSnakeB[i].Image = picDalala[1].Image;
                }
                else if (picSnakeB[i].Location.X == picSnakeB[i - 1].Location.X &&
                         picSnakeB[i].Location.Y < picSnakeB[i - 1].Location.Y)
                {
                    picSnakeB[i].Image = picDalala[2].Image;
                }
                else if (picSnakeB[i].Location.X > picSnakeB[i - 1].Location.X &&
                         picSnakeB[i].Location.Y == picSnakeB[i - 1].Location.Y)
                {
                    picSnakeB[i].Image = picDalala[3].Image;
                }
                else if (picSnakeB[i].Location.X < picSnakeB[i - 1].Location.X &&
                         picSnakeB[i].Location.Y == picSnakeB[i - 1].Location.Y)
                {
                    picSnakeB[i].Image = picDalala[4].Image;
                }
            }
            for (int i = 1; i < picSnakeB.Length - 1; i++)
            {
                if (picSnakeB[i + 1].Location.X > picSnakeB[i - 1].Location.X &&
                    picSnakeB[i + 1].Location.Y != picSnakeB[i - 1].Location.Y)
                {
                    picSnakeB[i].Image = picDalala[5].Image;
                }
                else if (picSnakeB[i + 1].Location.X < picSnakeB[i - 1].Location.X &&
                         picSnakeB[i + 1].Location.Y != picSnakeB[i - 1].Location.Y)
                {
                    picSnakeB[i].Image = picDalala[6].Image;
                }
            }
        }

        private void RemoveItem(char a, int b)
        {
            try //exception of no existence of the item
            {
                this.Controls.Remove(itemLala[b]);
            }
            catch (Exception)
            {
                return;
            }
            ItemEffect(a, b);
        }

        private void ItemEffect(char a,int i)  // add effect to snakeA or snakeB
        {
            if (itemLala[i].Image == picDalala[8].Image)
            {
                if (a == 'A')
                    snakeA.speed += 10;
                else if (a == 'B')
                    snakeB.speed += 10;
            }
            else if (itemLala[i].Image == picDalala[9].Image)
            {
                if (a == 'A')
                    snakeA.speed += 20;
                else if (a == 'B')
                    snakeB.speed += 20;
            }
            else if (itemLala[i].Image == picDalala[10].Image)
            {
                if (a == 'A')
                    snakeA.speed -= 10;
                else if (a == 'B')
                    snakeB.speed -= 10;
            }
            else if (itemLala[i].Image == picDalala[11].Image)
            {
                if (a == 'A')
                    snakeA.speed -= 20;
                else if (a == 'B')
                    snakeB.speed -= 20;
            }
            else if (itemLala[i].Image == picDalala[12].Image)
            {
                if (a == 'A')
                    snakeA.speed += 60;
                else if (a == 'B')
                    snakeB.speed += 60;
            }
            else if (itemLala[i].Image == picDalala[13].Image)
            {
                if (a == 'A')
                    snakeA.speed += 100;
                else if (a == 'B')
                    snakeB.speed += 100;
            }
            else if (itemLala[i].Image == picDalala[14].Image)
            {
                if (a == 'A')
                    snakeA.speed += 80;
                else if (a == 'B')
                    snakeB.speed += 80;
            }
            if (a == 'A')
                Add1('A');
            else if (a == 'B')
                Add1('B');
        }
        private void Add1(char a)  //adding 1 more Lala to the last position
        {
            if (a == 'A')
            {
                int S, L, X, Y;
                S = snakeA.size;
                L = picSnakeA.Length;
                X = picSnakeA[L - 1].Location.X;
                Y = picSnakeA[L - 1].Location.Y;

                snakeA.length += 1;
                Array.Resize<PictureBox>(ref picSnakeA, L + 1);  //expand array "Resize"
                picSnakeA[L] = new PictureBox(); //current Length = index of the new one
                picSnakeA[L].Image = picSnakeA[L - 1].Image; 
                // the new one is the same as the current last one
                if (picSnakeA[L - 1].Image == picDalala[1].Image)   //according to the direction of the last one to define the new one
                    picSnakeA[L].Location = new Point(X, Y + S);//upward: add new one Y+S(size) 
                else if (picSnakeA[L - 1].Image == picDalala[2].Image)
                    picSnakeA[L].Location = new Point(X, Y - S);//downward: add new one Y-S 
                else if (picSnakeA[L - 1].Image == picDalala[3].Image)
                    picSnakeA[L].Location = new Point(X + S, Y);//leftward: add new one X+S
                else if (picSnakeA[L - 1].Image == picDalala[4].Image)
                    picSnakeA[L].Location = new Point(X - S, Y);//rightward:

                picSnakeA[L].SizeMode = PictureBoxSizeMode.AutoSize;
                this.Controls.Add(picSnakeA[L]);
            }
            else if (a == 'B')
            {
                int S, L, X, Y;
                S = snakeB.size;
                L = picSnakeB.Length;
                X = picSnakeB[L - 1].Location.X;
                Y = picSnakeB[L - 1].Location.Y;

                snakeB.length += 1;
                Array.Resize<PictureBox>(ref picSnakeB, L + 1);
                picSnakeB[L] = new PictureBox();
                picSnakeB[L].Image = picSnakeB[L - 1].Image;

                if (picSnakeB[L - 1].Image == picDalala[1].Image)
                    picSnakeB[L].Location = new Point(X, Y + S);
                else if (picSnakeB[L - 1].Image == picDalala[2].Image)
                    picSnakeB[L].Location = new Point(X, Y - S);
                else if (picSnakeB[L - 1].Image == picDalala[3].Image)
                    picSnakeB[L].Location = new Point(X + S, Y);
                else if (picSnakeB[L - 1].Image == picDalala[4].Image)
                    picSnakeB[L].Location = new Point(X - S, Y);

                picSnakeB[L].SizeMode = PictureBoxSizeMode.AutoSize;
                this.Controls.Add(picSnakeB[L]);
            }
        }

        private void CheckHitA()
        {
            if (snakeA.xAxis > Width-60 || snakeA.xAxis < 40 ||snakeA.yAxis > Height-75 || snakeA.yAxis < 40)
                GameOver('A');

            for (int i = 0; i < snakeB.length; i++)
            {
                bool a1, a2, b1, b2, c1, c2;
                a1 = snakeA.xAxis == picSnakeB[i].Location.X;
                a2 = snakeA.yAxis == picSnakeB[i].Location.Y;
                b1 = snakeA.xAxis == picSnakeB[i].Location.X + 20;
                b2 = snakeA.yAxis == picSnakeB[i].Location.Y + 20;
                c1 = snakeA.xAxis == picSnakeB[i].Location.X - 20;
                c2 = snakeA.yAxis == picSnakeB[i].Location.Y - 20;
                if ((a1 || b1 || c1) && (a2 || b2 || c2))
                {
                    GameOver('A');
                }
            }
        }

        private void CheckHitB()
        {
            if (snakeB.xAxis > Width-60 || snakeB.xAxis < 40 ||snakeB.yAxis > Height-75 || snakeB.yAxis < 40)
                GameOver('B');

            for (int i = 0; i < snakeA.length; i++)
            {
                bool a1, a2, b1, b2, c1, c2;
                a1 = snakeB.xAxis == picSnakeA[i].Location.X;
                a2 = snakeB.yAxis == picSnakeA[i].Location.Y;
                b1 = snakeB.xAxis == picSnakeA[i].Location.X + 20;
                b2 = snakeB.yAxis == picSnakeA[i].Location.Y + 20;
                c1 = snakeB.xAxis == picSnakeA[i].Location.X - 20;
                c2 = snakeB.yAxis == picSnakeA[i].Location.Y - 20;
                if ((a1 || b1 || c1) && (a2 || b2 || c2))
                {
                    GameOver('B');
                }
            }
        }

        private void GameOver(char a)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            if (a == 'A')
            {
                gameOver = 1;
                for (int i = 0; i < picSnakeA.Length; i++)
                {
                        if (i == 0 || i == picSnakeA.Length - 1)
                            picSnakeA[i].Image = picDalala[17].Image;
                        else
                            picSnakeA[i].Image = picDalala[18].Image;
                }

                for (int i = 0; i < picSnakeB.Length; i++)
                {
                        if (i == 0 || i == picSnakeB.Length - 1)
                            picSnakeB[i].Image = picDalala[15].Image;
                        else
                            picSnakeB[i].Image = picDalala[16].Image;
                }
            }
            else if (a == 'B')
            {
                gameOver = 2;
                for (int i = 0; i < picSnakeB.Length; i++)
                {
                    if (i == 0 || i == picSnakeB.Length - 1)
                        picSnakeB[i].Image = picDalala[17].Image;
                    else
                        picSnakeB[i].Image = picDalala[18].Image;
                }
                for (int i = 0; i < picSnakeA.Length; i++)
                {
                    if (i == 0 || i == picSnakeA.Length - 1)
                        picSnakeA[i].Image = picDalala[15].Image;
                    else
                        picSnakeA[i].Image = picDalala[16].Image;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {//wsad for snakeA and "arrow" for snakeB 
            if (e.KeyValue == 87 || e.KeyValue == 83 || e.KeyValue == 65 || e.KeyValue == 68)
            {// for snakeA  w87  s83  a65  d68   //up:1 down:2 left:3 right:4
                autoMoveA = false;
                if (e.KeyValue == 87)
                {
                    if (snakeA.direction == 2)
                        return;
                    snakeA.direction = 1;
                }
                else if (e.KeyValue == 83)
                {
                    if (snakeA.direction == 1)
                        return;
                    snakeA.direction = 2;
                }
                else if (e.KeyValue == 65)
                {
                    if (snakeA.direction == 4)
                        return;
                    snakeA.direction = 3;
                }
                else if (e.KeyValue == 68)
                {
                    if (snakeA.direction == 3)
                        return;
                    snakeA.direction = 4;
                }
            }
            else if (e.KeyValue == 73 || e.KeyValue == 74 || e.KeyValue == 75 || e.KeyValue == 76)
            {//ijkl for snakeB 
                autoMoveB = false;
                if (e.KeyValue == 73)  //i
                {
                    if (snakeB.direction == 2)
                        return;
                    snakeB.direction = 1;
                }
                else if (e.KeyValue == 75)  //k
                {
                    if (snakeB.direction == 1)
                        return;
                    snakeB.direction = 2;
                }
                else if (e.KeyValue == 74)  //j
                {
                    if (snakeB.direction == 4)
                        return;
                    snakeB.direction = 3;
                }
                else if (e.KeyValue == 76) //L
                {
                    if (snakeB.direction == 3)
                        return;
                    snakeB.direction = 4;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)  //move snakeA 
        {
            if (autoMoveA)
            {
                int autoDir = new Random().Next(1, 9);
                if (autoDir <4)
                    if (autoDir == 1 && snakeA.direction != 2)
                        snakeA.direction = autoDir;
                    else if (autoDir == 2 && snakeA.direction != 1)
                        snakeA.direction = autoDir;
                    else if (autoDir == 3 && snakeA.direction != 4)
                        snakeA.direction = autoDir;
                    else if (autoDir == 4 && snakeA.direction != 3)
                        snakeA.direction = autoDir;
            }
                
            if (snakeA.speed < 100)
                snakeA.speed = 100;
            else if (snakeA.speed > 1000)
                snakeA.speed = 1000;
            else
                timer1.Interval = snakeA.speed;
            switch (snakeA.direction)
            {
                case 1:
                    snakeA.yAxis -= snakeA.size;
                    break;
                case 2:
                    snakeA.yAxis += snakeA.size;
                    break;
                case 3:
                    snakeA.xAxis -= snakeA.size;
                    break;
                case 4:
                    snakeA.xAxis += snakeA.size;
                    break;
            }
            SnakeMove('A');
            CheckHitA();
            for(int i = 0; i < itemLala.Length; i++)
            {
                bool a1, a2, b1, b2, c1, c2;
                a1 = snakeA.xAxis == itemLala[i].Location.X;
                a2 = snakeA.yAxis == itemLala[i].Location.Y;
                b1 = snakeA.xAxis == itemLala[i].Location.X + 20;
                b2 = snakeA.yAxis == itemLala[i].Location.Y + 20;
                c1 = snakeA.xAxis == itemLala[i].Location.X - 20;
                c2 = snakeA.yAxis == itemLala[i].Location.Y - 20;
                if ((a1 || b1 || c1) && (a2 || b2 || c2))
                {
                    RemoveItem('A', i);
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e) //move snakeB
        {
            if (autoMoveB)
            {
                int autoDir = new Random().Next(1, 9);
                if (autoDir == 1 && snakeB.direction !=2) 
                    snakeB.direction = autoDir;
                else if (autoDir == 2 && snakeB.direction != 1)
                    snakeB.direction = autoDir;
                else if (autoDir == 3 && snakeB.direction != 4)
                    snakeB.direction = autoDir;
                else if (autoDir == 4 && snakeB.direction != 3)
                    snakeB.direction = autoDir;
            }
            if (snakeB.speed < 100)  //minium of speed
                snakeB.speed = 100;
            else if (snakeB.speed > 1000) //maxnum of speed
                snakeB.speed = 1000;
            else
                timer2.Interval = snakeB.speed;
            switch (snakeB.direction)  //according to the direction to move snakeB(head)
            {
                case 1:
                    snakeB.yAxis -= snakeB.size;
                    break;
                case 2:
                    snakeB.yAxis += snakeB.size;
                    break;
                case 3:
                    snakeB.xAxis -= snakeB.size;
                    break;
                case 4:
                    snakeB.xAxis += snakeB.size;
                    break;
            }
            SnakeMove('B');  //move the pic(body) of snakeB
            CheckHitB();
            for (int i = 0; i < itemLala.Length; i++)  //judging hit
            {
                bool a1, a2, b1, b2, c1, c2;
                a1 = snakeB.xAxis == itemLala[i].Location.X;
                a2 = snakeB.yAxis == itemLala[i].Location.Y;
                b1 = snakeB.xAxis == itemLala[i].Location.X + 20;
                b2 = snakeB.yAxis == itemLala[i].Location.Y + 20;
                c1 = snakeB.xAxis == itemLala[i].Location.X - 20;
                c2 = snakeB.yAxis == itemLala[i].Location.Y - 20;
                if ((a1 || b1 || c1) && (a2 || b2 || c2))
                {
                    RemoveItem('B', i);
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)  //implement items
        {
            changeColor();
            int x, y;
            int itemPop;

            Random rd = new Random();
            x = rd.Next(6, 90); //x axis=x*20
            y = rd.Next(6, 48); //y axis=y*20
            itemPop = (rd.Next(0,15))*(rd.Next(0,15))%14;// for the name(code) of item picture
            if(itemPop >=8 )
            {
                itemLala[itemNum].Image = picDalala[itemPop].Image;
                itemLala[itemNum].Location = new Point(x*20, y*20);
                itemLala[itemNum].SizeMode = PictureBoxSizeMode.AutoSize;
                itemLala[itemNum].BorderStyle = BorderStyle.None;
                this.Controls.Add(itemLala[itemNum]);

                itemNum++;
                if (itemNum >= 5)
                    itemNum = 0;                   
            }
        }
        private void timer4_Tick(object sender, EventArgs e)//reset and restart and return
        {
            if (!gameStarted)
            {
                Start();// start here (after window mixmized) to prevend wrong position for snakeB 
                gameStarted = true;
            }
                
            if (xM != Cursor.Position.X || yM != Cursor.Position.Y)
            {
                this.Close();
                Cursor.Show();
            }

            if (gameOver>0)
            {
                string temp = gameOver == 1 ? "Player2獲勝，" : "Player2獲勝，";
                txtDown.Text = temp+"目前是「GAME OVER」狀態，預計「" + (autoResetCount-- / 4 +1)+ "」秒後自動重啟！";
                if (autoResetCount == 0)
                {
                    txtDown.Text = "暫時沒事可以寫";
                    autoResetCount = 12;
                    gameOver = 0;
                    autoReset();
                }
            }
        }

        private void autoReset()
        {
            for (int i = 0; i < picSnakeA.Length; i++)
                this.Controls.Remove(picSnakeA[i]);
            try
            {
                for (int i = 0; i < picSnakeB.Length; i++)
                    this.Controls.Remove(picSnakeB[i]);
            }
            catch (Exception)
            {
                return;
            }
            if (itemLala.Length != 0)
            {
                for (int i = 0; i < itemLala.Length; i++)
                    this.Controls.Remove(itemLala[i]);
            }
            snakeA.xAxis = 280;
            snakeA.yAxis = 200;
            snakeA.direction = 2;
            snakeB.xAxis = Width - 320;
            snakeB.yAxis = Height - 240;
            snakeB.direction = 1;
            snakeA.picture = snakeB.picture= 1;
            snakeA.length = snakeB.length= 5;
            snakeA.speed = snakeB.speed=500;
            snakeA.size = snakeB.size=40;

            itemNum = 0;
            timer1.Enabled= timer2.Enabled = timer3.Enabled = false;
            timer1.Interval = timer2.Interval=snakeA.speed;//same
            timer3.Interval = 1300;
            Start();
        }

        private void changeColor()
        {   
            int n = new Random().Next(0, 6);
            switch (n)
            {
                case 0:
                    txtUp.BackColor = txtDown.BackColor = txtLeft.BackColor = txtRight.BackColor = Color.Black;
                    txtUp.ForeColor = txtDown.ForeColor = txtLeft.ForeColor = txtRight.ForeColor = Color.White;
                    break;
                case 1:
                    txtUp.BackColor = txtDown.BackColor = txtLeft.BackColor = txtRight.BackColor = Color.LightBlue;
                    txtUp.ForeColor = txtDown.ForeColor = txtLeft.ForeColor = txtRight.ForeColor = Color.Red;
                    break;
                case 2:
                    txtUp.BackColor = txtDown.BackColor = txtLeft.BackColor = txtRight.BackColor = Color.LightGreen;
                    txtUp.ForeColor = txtDown.ForeColor = txtLeft.ForeColor = txtRight.ForeColor = Color.Purple;
                    break;
                case 3:
                    txtUp.BackColor = txtDown.BackColor = txtLeft.BackColor = txtRight.BackColor = Color.DarkKhaki;
                    txtUp.ForeColor = txtDown.ForeColor = txtLeft.ForeColor = txtRight.ForeColor = Color.LightCyan;
                    break;
                case 4:
                    txtUp.BackColor = txtDown.BackColor = txtLeft.BackColor = txtRight.BackColor = Color.White;
                    txtUp.ForeColor = txtDown.ForeColor = txtLeft.ForeColor = txtRight.ForeColor = Color.Black;
                    break;
                case 5:
                    txtUp.BackColor = txtDown.BackColor = txtLeft.BackColor = txtRight.BackColor = Color.DarkBlue;
                    txtUp.ForeColor = txtDown.ForeColor = txtLeft.ForeColor = txtRight.ForeColor = Color.LightPink;
                    break;
            }
        }
    }
}
