using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace UserModule_DAYOFWEEK_AND_TIME_TO_ANALOG_V1
{
    public class UserModuleClass_DAYOFWEEK_AND_TIME_TO_ANALOG_V1 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput UPDATE;
        Crestron.Logos.SplusObjects.AnalogOutput DAY_OF_WEEK;
        Crestron.Logos.SplusObjects.AnalogOutput TIME_IN_MINUTES;
        object UPDATE_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort IDAYOFWEEK = 0;
                ushort ICALCULATEDTIME = 0;
                
                
                __context__.SourceCodeLine = 36;
                IDAYOFWEEK = (ushort) ( Functions.GetDayOfWeekNum() ) ; 
                __context__.SourceCodeLine = 37;
                ICALCULATEDTIME = (ushort) ( ((Functions.GetHourNum() * 60) + Functions.GetMinutesNum()) ) ; 
                __context__.SourceCodeLine = 39;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IDAYOFWEEK != DAY_OF_WEEK  .Value))  ) ) 
                    {
                    __context__.SourceCodeLine = 40;
                    DAY_OF_WEEK  .Value = (ushort) ( IDAYOFWEEK ) ; 
                    }
                
                __context__.SourceCodeLine = 42;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ICALCULATEDTIME != TIME_IN_MINUTES  .Value))  ) ) 
                    {
                    __context__.SourceCodeLine = 43;
                    TIME_IN_MINUTES  .Value = (ushort) ( ICALCULATEDTIME ) ; 
                    }
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    public override object FunctionMain (  object __obj__ ) 
        { 
        try
        {
            SplusExecutionContext __context__ = SplusFunctionMainStartCode();
            
            __context__.SourceCodeLine = 51;
            DAY_OF_WEEK  .Value = (ushort) ( Functions.GetDayOfWeekNum() ) ; 
            __context__.SourceCodeLine = 52;
            TIME_IN_MINUTES  .Value = (ushort) ( ((Functions.GetHourNum() * 60) + Functions.GetMinutesNum()) ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        UPDATE = new Crestron.Logos.SplusObjects.DigitalInput( UPDATE__DigitalInput__, this );
        m_DigitalInputList.Add( UPDATE__DigitalInput__, UPDATE );
        
        DAY_OF_WEEK = new Crestron.Logos.SplusObjects.AnalogOutput( DAY_OF_WEEK__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( DAY_OF_WEEK__AnalogSerialOutput__, DAY_OF_WEEK );
        
        TIME_IN_MINUTES = new Crestron.Logos.SplusObjects.AnalogOutput( TIME_IN_MINUTES__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( TIME_IN_MINUTES__AnalogSerialOutput__, TIME_IN_MINUTES );
        
        
        UPDATE.OnDigitalPush.Add( new InputChangeHandlerWrapper( UPDATE_OnPush_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_DAYOFWEEK_AND_TIME_TO_ANALOG_V1 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint UPDATE__DigitalInput__ = 0;
    const uint DAY_OF_WEEK__AnalogSerialOutput__ = 0;
    const uint TIME_IN_MINUTES__AnalogSerialOutput__ = 1;
    
    [SplusStructAttribute(-1, true, false)]
    public class SplusNVRAM : SplusStructureBase
    {
    
        public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
        
        
    }
    
    SplusNVRAM _SplusNVRAM = null;
    
    public class __CEvent__ : CEvent
    {
        public __CEvent__() {}
        public void Close() { base.Close(); }
        public int Reset() { return base.Reset() ? 1 : 0; }
        public int Set() { return base.Set() ? 1 : 0; }
        public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
    }
    public class __CMutex__ : CMutex
    {
        public __CMutex__() {}
        public void Close() { base.Close(); }
        public void ReleaseMutex() { base.ReleaseMutex(); }
        public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
    }
     public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
