using Xunit;

namespace MeAndNatalieLearningCSharp
{
    public class ValueTypeVsReferenceType
    {
        [Fact]
        public void ValueTypeVsReferenceTypeTests()
        {
            int myInt = 1;
            int myInt2 = myInt;
            myInt2 = 2;

            //What is the value of myInt and value of myInt2?

            string myString = "my string 1";
            string myString2 = myString;
            myString2 = "my string 2";
            //What is the value of myString and value of myString2?
        }

        [Fact]
        public void ValueTypeVsReferenceTypeEqualityTests()
        {
            int myInt = 1;
            int myInt2 = 1;

            bool areIntsEqual = myInt2 == myInt;

            //What is the value of myInt and value of myInt2?

            string myString = "my string";
            string myString2 =  "my string";
            //What is the value of myString and value of myString2?

            bool areStringsEqual = myString == myString2;
        }
        
        [Fact]
        public void ValueTypeVsReferenceTypeTests_Pointers()
        {
            int myInt = 1;
            unsafe
            {
                int* myInt2 = &myInt;
                *myInt2 = 2;
            }

            //What is the value of myInt?

            string myString = "my string 1";
            string myString2 = myString;
            myString2 = "my string 2";
            //What is the value of myString and value of myString2?
        }
        
        [Fact]
        public void StructVsClassTests()
        {
            StructIntWrapper structIntWrapper  = new StructIntWrapper();
            structIntWrapper.MyInt = 1;
            StructIntWrapper structIntWrapper2 = structIntWrapper;
            structIntWrapper2.MyInt = 2;
            //What is the value of structIntWrapper.MyInt and value of structIntWrapper.MyInt2?
            bool areStructIntsEqual = structIntWrapper.MyInt == structIntWrapper2.MyInt;


            ClassIntWrapper classIntWrapper = new ClassIntWrapper();
            classIntWrapper.MyInt = 1;
            ClassIntWrapper classIntWrapper2 = classIntWrapper;
            classIntWrapper2.MyInt = 2;
            //What is the value of classIntWrapper2.myInt and value of classIntWrapper2.myInt?
            bool areClassIntsEqual = classIntWrapper.MyInt == classIntWrapper2.MyInt;

        }

        [Fact]
        public void StructVsClassTests_Mutate()
        {
            StructIntWrapper structIntWrapper = new StructIntWrapper();
            structIntWrapper.MyInt = 1;

            Mutate(structIntWrapper);

            ClassIntWrapper classIntWrapper = new ClassIntWrapper();
            classIntWrapper.MyInt = 1;

            Mutate(classIntWrapper);
        }


        public void Mutate(IntWrapper intWrapper) => intWrapper.MyInt = 10;


        public interface IntWrapper
        {
            int MyInt { get; set; }
        }
        
        public struct StructIntWrapper : IntWrapper
        {
            public StructIntWrapper(int myInt)
            {
                MyInt = myInt;  
            }

            public int MyInt { get; set; }
        }

        public class ClassIntWrapper : IntWrapper
        {
            public int MyInt { get; set; }
        }
    }
}
