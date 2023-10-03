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

namespace UserModule_CONTROLWORKS_TIME_ANALOG_TO_AMPMSTRING_V1_0
{
    public class UserModuleClass_CONTROLWORKS_TIME_ANALOG_TO_AMPMSTRING_V1_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        Crestron.Logos.SplusObjects.AnalogInput TIMEIN;
        Crestron.Logos.SplusObjects.StringOutput FORMATTEDTIMEFB__DOLLAR__;
        object TIMEIN_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 29;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TIMEIN  .UshortValue == 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 30;
                    FORMATTEDTIMEFB__DOLLAR__  .UpdateValue ( "12:00 M"  ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 31;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TIMEIN  .UshortValue == 720))  ) ) 
                        {
                        __context__.SourceCodeLine = 32;
                        FORMATTEDTIMEFB__DOLLAR__  .UpdateValue ( "12:00 N"  ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 33;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( TIMEIN  .UshortValue < 60 ))  ) ) 
                            {
                            __context__.SourceCodeLine = 34;
                            MakeString ( FORMATTEDTIMEFB__DOLLAR__ , "{0:d}:{1:d2} AM", (ushort)((TIMEIN  .UshortValue + 720) / 60), (ushort)Mod( TIMEIN  .UshortValue , 60 )) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 35;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( TIMEIN  .UshortValue < 720 ))  ) ) 
                                {
                                __context__.SourceCodeLine = 36;
                                MakeString ( FORMATTEDTIMEFB__DOLLAR__ , "{0:d}:{1:d2} AM", (ushort)(TIMEIN  .UshortValue / 60), (ushort)Mod( TIMEIN  .UshortValue , 60 )) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 37;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( TIMEIN  .UshortValue < 780 ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 38;
                                    MakeString ( FORMATTEDTIMEFB__DOLLAR__ , "{0:d}:{1:d2} PM", (ushort)(TIMEIN  .UshortValue / 60), (ushort)Mod( TIMEIN  .UshortValue , 60 )) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 40;
                                    MakeString ( FORMATTEDTIMEFB__DOLLAR__ , "{0:d}:{1:d2} PM", (ushort)((TIMEIN  .UshortValue - 720) / 60), (ushort)Mod( (TIMEIN  .UshortValue - 720) , 60 )) ; 
                                    }
                                
                                }
                            
                            }
                        
                        }
                    
                    }
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        TIMEIN = new Crestron.Logos.SplusObjects.AnalogInput( TIMEIN__AnalogSerialInput__, this );
        m_AnalogInputList.Add( TIMEIN__AnalogSerialInput__, TIMEIN );
        
        FORMATTEDTIMEFB__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( FORMATTEDTIMEFB__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( FORMATTEDTIMEFB__DOLLAR____AnalogSerialOutput__, FORMATTEDTIMEFB__DOLLAR__ );
        
        
        TIMEIN.OnAnalogChange.Add( new InputChangeHandlerWrapper( TIMEIN_OnChange_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_CONTROLWORKS_TIME_ANALOG_TO_AMPMSTRING_V1_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint TIMEIN__AnalogSerialInput__ = 0;
    const uint FORMATTEDTIMEFB__DOLLAR____AnalogSerialOutput__ = 0;
    
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
