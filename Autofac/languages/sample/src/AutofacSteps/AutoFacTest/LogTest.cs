

using AutofacSamples;

namespace AutoFacTest
{
    public class LogTest
    {
        [Fact]
        public void Sample1Test()
        {
            var builder = new ContainerBuilder();
            //Ilist<T> ==> List<T>
            //Ilist<int> ==> List<int>

            builder.RegisterGeneric(typeof(List<>)).As(typeof(IList<>));
            var container=builder.Build();

            var mylist=container.Resolve<IList<int>>();
            var name = mylist.GetType().Name;
            Assert.Equal("List`1",name);

        }
    }

}
