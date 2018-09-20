using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppTest
{

    public abstract class GenericParameter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public object Value { get; set; }

    }

    public class ControlParameter : GenericParameter
    {

    }
    public class ConfigurationParameter : GenericParameter
    {

    }
    public class MeasurementParameter : GenericParameter
    {

    }
    public class CalculatedParameter : GenericParameter
    {

    }

    public abstract class SubSystem : IParameter
    {
        public int Id { get; set; }
        public string RefId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SoftwareVersion { get; set; }
        public string HardwareVersion { get; set; }

        public object GetParameter(int parameterId)
        {
            return null;
        }

        public void SetParameter(int value)
        {           
        }
    }

    public interface IDynamometer
    {
        void SetMoment(int bor, int ar);
        void SetRpm(int bor, int ar);
    }
    public class Dynamometer : SubSystem, IDynamometer
    {
        public void SetMoment(int bor, int ar)
        {
        }

        public void SetRpm(int bor, int ar)
        {      
        }
    }

    public class Inverter : SubSystem
    {
    }

    public class ClimateBox : SubSystem
    {

    }

    public interface IParameter
    {
        void SetParameter(int value);
        object GetParameter(int parameterId);
    }

    public enum eRigStatus
    {
        Idle, Preparation, Running
    }
    public abstract class GenericRig
    {
        public int Id { get; set; }
        public string RefId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SubSystem> SubSystems { get; set; }
        public TestObject TestObject { get; set; }
    }

    public abstract class GenericTestObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<GenericParameter> Parameters { get; set; }
    }

    public class Action
    {
        public void Execute() { }
    }

    public class TestCycle
    {
        public Queue<Action> Actions { get; set; }
    }

    public abstract class TestEngine
    {
        public void Tick() { }
        public Queue<TestCycle> TestCycles { get; set; }
    }
}
