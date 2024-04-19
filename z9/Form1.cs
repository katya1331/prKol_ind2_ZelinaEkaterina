using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace z9
{
   
    public partial class Form1 : Form
    {

        Queue<Student> goodStudents = new Queue<Student>();
        Queue<Student> badStudents = new Queue<Student>();
        public Form1()
        {
            InitializeComponent();
            string[] lines = File.ReadAllLines("1.txt");

            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                Student student = new Student
                {
                    LastName = data[0],
                    FirstName = data[1],
                    MiddleName = data[2],
                    Group = data[3],
                    Grades = data.Skip(4).Select(int.Parse).ToArray()
                };

                if (student.Grades.All(grade => grade >= 4))
                {
                    goodStudents.Enqueue(student);
                }
                else
                {
                    badStudents.Enqueue(student);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var student in goodStudents)
            {
                listBox1.Items.Add($"{student.LastName} {student.FirstName} {student.MiddleName}, Группа: {student.Group}, Оценки: {string.Join(", ", student.Grades)}");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var student in badStudents)
            {
                listBox1.Items.Add($"{student.LastName} {student.FirstName} {student.MiddleName}, Группа: {student.Group}, Оценки: {string.Join(", ", student.Grades)}");
            }
        }
        class Student
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string Group { get; set; }
            public int[] Grades { get; set; }
        }
    }
}
