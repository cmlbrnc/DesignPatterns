using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    // live course on udemy: student ask question online  : chatting
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator=new Mediator();
            
            Teacher jack = new Teacher(mediator) { Name = "Engin" };

            mediator.Teacher = jack;

            Student joe= new Student(mediator){Name="Joe"};
            
        

            Student juile = new Student(mediator) { Name = "juile" };

            mediator.Students = new List<Student>{joe,juile};

            jack.SendNewImageUrl("slide1.jpg");

            jack.RecieveQuestion("is it true?",juile);

            Console.ReadLine();
        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;

        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }

    }

    class Teacher:CourseMember
    {
        public string Name { get; internal set; }

        public Teacher(Mediator mediator) : base(mediator)
        {
        }

        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher reieved a question from {0},{1}",student.Name,question);
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide:{0}",url);

            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer,Student student)
        {
            Console.WriteLine("Teacher answered question {0},{1}",student.Name,answer);

        }

        
    }

    class Student : CourseMember
    {

        public Student(Mediator mediator) : base(mediator)
        {
        }
        public void RecieveImage(string url)
        {
           Console.WriteLine("Student received image: {0}",url);
        }

        public void ReceiveAnswer(string answer)
        {
            Console.WriteLine("Student received answer{0}",answer);
          
        }

        public string Name { get; set; }

     
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }

        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {

            Teacher.RecieveQuestion(question,student);

        }

        public void SendAnswer(string answer,Student student)
        {
            student.ReceiveAnswer(answer);
        }
    }
}
