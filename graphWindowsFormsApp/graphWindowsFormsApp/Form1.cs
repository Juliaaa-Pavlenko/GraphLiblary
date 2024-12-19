using System;
using System.Drawing;
using System.Windows.Forms;
using GraphLibrary;
using System.Collections.Generic;

namespace graphWindowsFormsApp
{
    public partial class Form1 : Form
    {
        private Container container = new Container();
        private Random random = new Random();
        private List<Point> topPositions = new List<Point>();

        public Form1()
        {
            InitializeComponent();
            this.drawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingPanel_Paint);
        }

        private void ButtonFindAdjacentArcs_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TextBoxTopNumber.Text, out int topNumber))
            {
                int adjacentArcs = container.GetAdjacentArcCount(topNumber);

                listBox.Items.Add($"Top {topNumber} has {adjacentArcs} adjacent arcs.");
            }
            else
            {
                listBox.Items.Add("Invalid top number. Please enter a valid integer.");
            }
        }

        private void btnAddTop_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtTopNumber.Text, out int number))
            {
                if (container.FindNumber(number) != null)
                {
                    MessageBox.Show("A top with this number already exists.");
                    return;
                }

                Top top = new Top(number);
                Point newPosition = GenerateTopPosition();
                topPositions.Add(newPosition);

                container.Add(top);
                UpdateList();
                drawingPanel.Invalidate();
            }
            else
            {
                MessageBox.Show("Please enter a valid number for the top.");
            }
        }

        private void btnCountTops_Click(object sender, EventArgs e)
        {
            int topCount = 0;

            foreach (var element in container.GetAll())
            {
                if (element is Top)
                {
                    topCount++;
                }
            }

            listBox.Items.Add($"Total tops: {topCount}");
        }

        private void btnAddArc_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtArcNumber.Text, out int number) &&
                int.TryParse(txtArcStart.Text, out int start) &&
                int.TryParse(txtArcEnd.Text, out int end))
            {
                if (container.FindNumber(start) == null || container.FindNumber(end) == null)
                {
                    MessageBox.Show("Start or end top does not exist.");
                    return;
                }

                Arc arc = new Arc(number, start, end);
                container.Add(arc);
                UpdateList();
                drawingPanel.Invalidate();
            }
            else
            {
                MessageBox.Show("Please enter valid numbers for the arc.");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtRemoveNumber.Text, out int number))
            {
                Graph element = container.FindNumber(number);
                if (element != null)
                {
                    container.Remove(element);

                    if (element is Top)
                    {
                        int index = container.GetAll().IndexOf(element);
                        if (index >= 0 && index < topPositions.Count)
                        {
                            topPositions.RemoveAt(index);
                        }
                    }

                    UpdateList();
                    drawingPanel.Invalidate();
                }
                else
                {
                    MessageBox.Show("Element not found.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number to remove.");
            }
        }

        private void UpdateList()
        {
            listBox.Items.Clear();
            foreach (var item in container.GetAll())
            {
                listBox.Items.Add(item.inf());
            }
        }

        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < container.GetAll().Count; i++)
            {
                var element = container.GetAll()[i];

                if (element is Top top)
                {
                    Point position = topPositions[i];
                    DrawTop(g, top, position.X, position.Y);
                }
                else if (element is Arc arc)
                {
                    var startTop = (Top)container.FindNumber(arc.Start);
                    var endTop = (Top)container.FindNumber(arc.End);

                    if (startTop != null && endTop != null)
                    {
                        Point startPos = topPositions[container.GetAll().IndexOf(startTop)];
                        Point endPos = topPositions[container.GetAll().IndexOf(endTop)];
                        DrawArc(g, arc, startPos.X, startPos.Y, endPos.X, endPos.Y);
                    }
                }
            }
        }

        private Point GenerateTopPosition()
        {
            int panelWidth = drawingPanel.Width;
            int panelHeight = drawingPanel.Height;
            int margin = 50;

            double angle = topPositions.Count * (2 * Math.PI / 10);
            int radius = 100;
            int centerX = panelWidth / 2;
            int centerY = panelHeight / 2;

            int x = (int)(centerX + radius * Math.Cos(angle));
            int y = (int)(centerY + radius * Math.Sin(angle));

            return new Point(x, y);
        }

        private void DrawTop(Graphics g, Top top, int x, int y)
        {
            g.FillEllipse(Brushes.Orange, x, y, 40, 40);
            g.DrawString($"Top {top.Number}", new Font(this.Font.FontFamily, 10), Brushes.DarkGreen, x + 10, y + 10);
        }

        private void DrawArc(Graphics g, Arc arc, int x1, int y1, int x2, int y2)
        {
            g.DrawLine(Pens.Orange, x1 + 20, y1 + 20, x2 + 20, y2 + 20);
            g.DrawString($"Arc {arc.Number}", this.Font, Brushes.Black, (x1 + x2) / 2, (y1 + y2) / 2);
        }

        private void lblTopNumber_Click(object sender, EventArgs e)
        {

        }
    }
}
