using System;
using System.Collections.Generic;
using System.Text;

namespace Question01
{
    class MyAccessModifiers
    {
        private int birthYear;
        protected string personalInfo;
        private protected string IdNumber;
        private readonly byte averageMiddleAge = 50;

        public int Age { get => DateTime.Today.Year - birthYear; }
        internal string Name { get; set; }
        public string NickName { get; internal set; }


        public MyAccessModifiers(int birthYear, string idNumber, string personalInfo)
        {
            this.birthYear = birthYear;
            this.personalInfo = personalInfo;
            this.IdNumber = idNumber;
        }

        protected internal bool HasLivedHalfOfLife()
        {
            return Age >= averageMiddleAge;
        }

        public static bool operator ==(MyAccessModifiers fst, MyAccessModifiers snd)
        {
            return fst.Name == snd.Name && fst.Age == snd.Age && fst.personalInfo == snd.personalInfo;
        }

        public static bool operator !=(MyAccessModifiers fst, MyAccessModifiers snd)
        {
            return !(fst == snd);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as MyAccessModifiers);
        }

        protected bool Equals(MyAccessModifiers other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;

            return this == other;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
