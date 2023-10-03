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
using BiampTesiraLib3.Tesira_Support;
using BiampTesiraLib3.Parser;
using BiampTesiraLib3.Events;
using BiampTesiraLib3.ConfigInfo;
using BiampTesiraLib3.CCI_Support;
using BiampTesiraLib3.Components;
using BiampTesiraLib3.Model;
using BiampTesiraLib3.Comm;
using BiampTesiraLib3;
using CCI_Library;
using CCI_Library.Network;
using CCI_Library.WebScripting;
using CCI_Library.Debugger;

namespace UserModule_BIAMP_TESIRA_ROUTER_CONTROL_V3_3
{
    public class UserModuleClass_BIAMP_TESIRA_ROUTER_CONTROL_V3_3 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput POLL_ROUTER;
        Crestron.Logos.SplusObjects.DigitalInput ROUTE_INPUT;
        Crestron.Logos.SplusObjects.DigitalInput DEROUTE_INPUT;
        Crestron.Logos.SplusObjects.DigitalInput TOGGLE_INPUT;
        Crestron.Logos.SplusObjects.AnalogInput NEW_INPUT;
        Crestron.Logos.SplusObjects.DigitalOutput IS_INITIALIZED;
        Crestron.Logos.SplusObjects.DigitalOutput IS_ROUTED;
        Crestron.Logos.SplusObjects.AnalogOutput OUTPUT_ROUTED;
        Crestron.Logos.SplusObjects.DigitalInput ENABLE;
        Crestron.Logos.SplusObjects.DigitalOutput IS_QUARANTINED;
        StringParameter INSTANCE_TAG;
        StringParameter ROUTER_TYPE;
        UShortParameter OUTPUT;
        UShortParameter COMMAND_PROCESSOR_ID;
        BiampTesiraLib3.Components.RouterComponent COMPONENT;
        ushort ISREADY = 0;
        public void ONINITIALIZECHANGE ( object __sender__ /*BiampTesiraLib3.Components.RouterComponent SENDER */, BiampTesiraLib3.Events.UInt16EventArgs ARGS ) 
            { 
            RouterComponent  SENDER  = (RouterComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 124;
                IS_INITIALIZED  .Value = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONQUARANTINECHANGE ( object __sender__ /*BiampTesiraLib3.Components.RouterComponent SENDER */, BiampTesiraLib3.Events.UInt16EventArgs ARGS ) 
            { 
            RouterComponent  SENDER  = (RouterComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 129;
                IS_QUARANTINED  .Value = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONOUTPUTROUTEDCHANGE ( object __sender__ /*BiampTesiraLib3.Components.RouterComponent SENDER */, BiampTesiraLib3.Events.UInt16EventArgs ARGS ) 
            { 
            RouterComponent  SENDER  = (RouterComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 134;
                OUTPUT_ROUTED  .Value = (ushort) ( ARGS.Payload ) ; 
                __context__.SourceCodeLine = 136;
                IS_ROUTED  .Value = (ushort) ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (OUTPUT_ROUTED  .Value == NEW_INPUT  .UshortValue) ) && Functions.TestForTrue ( Functions.BoolToInt ( NEW_INPUT  .UshortValue > 0 ) )) ) ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        object POLL_ROUTER_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 145;
                COMPONENT . PollRouter ( ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object ROUTE_INPUT_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 150;
            COMPONENT . RouteInput ( (ushort)( NEW_INPUT  .UshortValue )) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object DEROUTE_INPUT_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 155;
        COMPONENT . DerouteInput ( (ushort)( NEW_INPUT  .UshortValue )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TOGGLE_INPUT_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 160;
        COMPONENT . ToggleInput ( (ushort)( NEW_INPUT  .UshortValue )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object NEW_INPUT_OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 165;
        IS_ROUTED  .Value = (ushort) ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (OUTPUT_ROUTED  .Value == NEW_INPUT  .UshortValue) ) && Functions.TestForTrue ( Functions.BoolToInt ( NEW_INPUT  .UshortValue > 0 ) )) ) ) ; 
        __context__.SourceCodeLine = 167;
        if ( Functions.TestForTrue  ( ( ROUTE_INPUT  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 169;
            COMPONENT . RouteInput ( (ushort)( NEW_INPUT  .UshortValue )) ; 
            __context__.SourceCodeLine = 170;
            Functions.Delay (  (int) ( 30 ) ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ENABLE_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 176;
        if ( Functions.TestForTrue  ( ( ISREADY)  ) ) 
            {
            __context__.SourceCodeLine = 177;
            COMPONENT . Configure ( (ushort)( COMMAND_PROCESSOR_ID  .Value ), INSTANCE_TAG  .ToString(), ROUTER_TYPE  .ToString(), (ushort)( OUTPUT  .Value )) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ENABLE_OnRelease_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 181;
        if ( Functions.TestForTrue  ( ( ISREADY)  ) ) 
            {
            __context__.SourceCodeLine = 182;
            COMPONENT . UnRegister ( ) ; 
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
        
        __context__.SourceCodeLine = 193;
        ISREADY = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 195;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 196;
        // RegisterEvent( COMPONENT , ONINITIALIZECHANGE , ONINITIALIZECHANGE ) 
        try { g_criticalSection.Enter(); COMPONENT .OnInitializeChange  += ONINITIALIZECHANGE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 197;
        // RegisterEvent( COMPONENT , ONQUARANTINECHANGE , ONQUARANTINECHANGE ) 
        try { g_criticalSection.Enter(); COMPONENT .OnQuarantineChange  += ONQUARANTINECHANGE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 198;
        // RegisterEvent( COMPONENT , ONOUTPUTROUTEDCHANGE , ONOUTPUTROUTEDCHANGE ) 
        try { g_criticalSection.Enter(); COMPONENT .OnOutputRoutedChange  += ONOUTPUTROUTEDCHANGE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 200;
        if ( Functions.TestForTrue  ( ( ENABLE  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 201;
            COMPONENT . Configure ( (ushort)( COMMAND_PROCESSOR_ID  .Value ), INSTANCE_TAG  .ToString(), ROUTER_TYPE  .ToString(), (ushort)( OUTPUT  .Value )) ; 
            }
        
        __context__.SourceCodeLine = 203;
        ISREADY = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    POLL_ROUTER = new Crestron.Logos.SplusObjects.DigitalInput( POLL_ROUTER__DigitalInput__, this );
    m_DigitalInputList.Add( POLL_ROUTER__DigitalInput__, POLL_ROUTER );
    
    ROUTE_INPUT = new Crestron.Logos.SplusObjects.DigitalInput( ROUTE_INPUT__DigitalInput__, this );
    m_DigitalInputList.Add( ROUTE_INPUT__DigitalInput__, ROUTE_INPUT );
    
    DEROUTE_INPUT = new Crestron.Logos.SplusObjects.DigitalInput( DEROUTE_INPUT__DigitalInput__, this );
    m_DigitalInputList.Add( DEROUTE_INPUT__DigitalInput__, DEROUTE_INPUT );
    
    TOGGLE_INPUT = new Crestron.Logos.SplusObjects.DigitalInput( TOGGLE_INPUT__DigitalInput__, this );
    m_DigitalInputList.Add( TOGGLE_INPUT__DigitalInput__, TOGGLE_INPUT );
    
    ENABLE = new Crestron.Logos.SplusObjects.DigitalInput( ENABLE__DigitalInput__, this );
    m_DigitalInputList.Add( ENABLE__DigitalInput__, ENABLE );
    
    IS_INITIALIZED = new Crestron.Logos.SplusObjects.DigitalOutput( IS_INITIALIZED__DigitalOutput__, this );
    m_DigitalOutputList.Add( IS_INITIALIZED__DigitalOutput__, IS_INITIALIZED );
    
    IS_ROUTED = new Crestron.Logos.SplusObjects.DigitalOutput( IS_ROUTED__DigitalOutput__, this );
    m_DigitalOutputList.Add( IS_ROUTED__DigitalOutput__, IS_ROUTED );
    
    IS_QUARANTINED = new Crestron.Logos.SplusObjects.DigitalOutput( IS_QUARANTINED__DigitalOutput__, this );
    m_DigitalOutputList.Add( IS_QUARANTINED__DigitalOutput__, IS_QUARANTINED );
    
    NEW_INPUT = new Crestron.Logos.SplusObjects.AnalogInput( NEW_INPUT__AnalogSerialInput__, this );
    m_AnalogInputList.Add( NEW_INPUT__AnalogSerialInput__, NEW_INPUT );
    
    OUTPUT_ROUTED = new Crestron.Logos.SplusObjects.AnalogOutput( OUTPUT_ROUTED__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( OUTPUT_ROUTED__AnalogSerialOutput__, OUTPUT_ROUTED );
    
    OUTPUT = new UShortParameter( OUTPUT__Parameter__, this );
    m_ParameterList.Add( OUTPUT__Parameter__, OUTPUT );
    
    COMMAND_PROCESSOR_ID = new UShortParameter( COMMAND_PROCESSOR_ID__Parameter__, this );
    m_ParameterList.Add( COMMAND_PROCESSOR_ID__Parameter__, COMMAND_PROCESSOR_ID );
    
    INSTANCE_TAG = new StringParameter( INSTANCE_TAG__Parameter__, this );
    m_ParameterList.Add( INSTANCE_TAG__Parameter__, INSTANCE_TAG );
    
    ROUTER_TYPE = new StringParameter( ROUTER_TYPE__Parameter__, this );
    m_ParameterList.Add( ROUTER_TYPE__Parameter__, ROUTER_TYPE );
    
    
    POLL_ROUTER.OnDigitalPush.Add( new InputChangeHandlerWrapper( POLL_ROUTER_OnPush_0, true ) );
    ROUTE_INPUT.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROUTE_INPUT_OnPush_1, true ) );
    DEROUTE_INPUT.OnDigitalPush.Add( new InputChangeHandlerWrapper( DEROUTE_INPUT_OnPush_2, true ) );
    TOGGLE_INPUT.OnDigitalPush.Add( new InputChangeHandlerWrapper( TOGGLE_INPUT_OnPush_3, true ) );
    NEW_INPUT.OnAnalogChange.Add( new InputChangeHandlerWrapper( NEW_INPUT_OnChange_4, true ) );
    ENABLE.OnDigitalPush.Add( new InputChangeHandlerWrapper( ENABLE_OnPush_5, true ) );
    ENABLE.OnDigitalRelease.Add( new InputChangeHandlerWrapper( ENABLE_OnRelease_6, true ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    COMPONENT  = new BiampTesiraLib3.Components.RouterComponent();
    
    
}

public UserModuleClass_BIAMP_TESIRA_ROUTER_CONTROL_V3_3 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint POLL_ROUTER__DigitalInput__ = 0;
const uint ROUTE_INPUT__DigitalInput__ = 1;
const uint DEROUTE_INPUT__DigitalInput__ = 2;
const uint TOGGLE_INPUT__DigitalInput__ = 3;
const uint NEW_INPUT__AnalogSerialInput__ = 0;
const uint IS_INITIALIZED__DigitalOutput__ = 0;
const uint IS_ROUTED__DigitalOutput__ = 1;
const uint OUTPUT_ROUTED__AnalogSerialOutput__ = 0;
const uint ENABLE__DigitalInput__ = 4;
const uint IS_QUARANTINED__DigitalOutput__ = 2;
const uint INSTANCE_TAG__Parameter__ = 10;
const uint ROUTER_TYPE__Parameter__ = 11;
const uint OUTPUT__Parameter__ = 12;
const uint COMMAND_PROCESSOR_ID__Parameter__ = 13;

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
