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
using AVProEdgeMXNetLib.Enums;
using AVProEdgeMXNetLib.Components.Abstract;
using AVProEdgeMXNetLib.Components;
using AVProEdgeMXNetLib.Models;
using AVProEdgeMXNetLib.Models.Endpoints;
using AVProEdgeMXNetLib.Utilities;
using AVProEdgeMXNetLib;
using AVProEdgeMXNetLib.EventArguments;
using AVProEdgeMXNetLib.Models.Layouts;
using AVProEdgeMXNetLib.JsonSupport;
using AVProEdgeMXNetLib.Interfaces;
using AVProEdgeMXNetLib.Enums.Attributes;
using CCI.SimplSharp.Library.Comm.Priority;
using CCI.SimplSharp.Library.Comm.Common;
using CCI.SimplSharp.Library.Comm.Model;
using CCI.SimplSharp.Library.Comm.Equality;
using CCI.SimplSharp.Library.Components.States;
using CCI.SimplSharp.Library.Components.EventArguments;
using CCI.SimplSharp.Library.Components.Common;
using CCI.SimplSharp.Library.Components.Registration;
using CCI.SimplSharp.Library.IO.Utilities;
using CCI.SimplSharp.Library.IO.Common;

namespace UserModule_AVPRO_EDGE_MXNET_COMMANDPROCESSOR_V1_2
{
    public class UserModuleClass_AVPRO_EDGE_MXNET_COMMANDPROCESSOR_V1_2 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput CONNECT;
        Crestron.Logos.SplusObjects.DigitalInput DISCONNECT;
        Crestron.Logos.SplusObjects.DigitalInput REINITIALIZE;
        Crestron.Logos.SplusObjects.DigitalInput DEBUGENABLE;
        Crestron.Logos.SplusObjects.DigitalInput SENDPASSTHRU;
        Crestron.Logos.SplusObjects.DigitalInput REBOOTCONTROLLER;
        Crestron.Logos.SplusObjects.DigitalInput REBOOTSYSTEM;
        Crestron.Logos.SplusObjects.DigitalInput ALLSCREENON;
        Crestron.Logos.SplusObjects.DigitalInput ALLSCREENFLASH;
        Crestron.Logos.SplusObjects.DigitalInput ALLSCREENOFF;
        Crestron.Logos.SplusObjects.DigitalInput ALLOSDON;
        Crestron.Logos.SplusObjects.DigitalInput ALLOSDOFF;
        Crestron.Logos.SplusObjects.AnalogInput DEBUG_LEVEL;
        Crestron.Logos.SplusObjects.StringInput IPADDRESS_INPUT;
        Crestron.Logos.SplusObjects.StringInput PASSTHRU;
        Crestron.Logos.SplusObjects.DigitalOutput ISCOMMUNICATING;
        Crestron.Logos.SplusObjects.DigitalOutput ISINITIALIZED;
        Crestron.Logos.SplusObjects.StringOutput DEVICE_IPADDRESS;
        UShortParameter COMMANDPROCESSORID;
        StringParameter IPADDRESS;
        UShortParameter POLLTIME;
        AVProEdgeMXNetLib.CommandProcessor COMM;
        AVProEdgeMXNetLib.Components.ControlBoxComponent CONTROL;
        ushort READY = 0;
        CrestronString MYIPADDRESS;
        private void RESETOUTPUTS (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 149;
            ISCOMMUNICATING  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 150;
            ISINITIALIZED  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 151;
            DEVICE_IPADDRESS  .UpdateValue ( ""  ) ; 
            
            }
            
        public void ONINITIALIZATIONCHANGE ( object __sender__ /*AVProEdgeMXNetLib.CommandProcessor SENDER */, AVProEdgeMXNetLib.EventArguments.AnaEventArgs ARGS ) 
            { 
            CommandProcessor  SENDER  = (CommandProcessor )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 158;
                ISINITIALIZED  .Value = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONCOMMUNICATIONCHANGE ( object __sender__ /*AVProEdgeMXNetLib.CommandProcessor SENDER */, AVProEdgeMXNetLib.EventArguments.AnaEventArgs ARGS ) 
            { 
            CommandProcessor  SENDER  = (CommandProcessor )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 163;
                ISCOMMUNICATING  .Value = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONDEBUGMESSAGE ( object __sender__ /*AVProEdgeMXNetLib.CommandProcessor SENDER */, AVProEdgeMXNetLib.EventArguments.SerEventArgs ARGS ) 
            { 
            CommandProcessor  SENDER  = (CommandProcessor )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 168;
                if ( Functions.TestForTrue  ( ( DEBUGENABLE  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 169;
                    Trace( "{0}", ARGS . Payload ) ; 
                    }
                
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONREADYSTATE ( object __sender__ /*AVProEdgeMXNetLib.CommandProcessor SENDER */, EventArgs E ) 
            { 
            CommandProcessor  SENDER  = (CommandProcessor )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 174;
                READY = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 176;
                if ( Functions.TestForTrue  ( ( CONNECT  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 177;
                    COMM . Connect ( ) ; 
                    }
                
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONIPADDRESS ( object __sender__ /*AVProEdgeMXNetLib.Components.ControlBoxComponent SENDER */, AVProEdgeMXNetLib.EventArguments.SerEventArgs ARGS ) 
            { 
            ControlBoxComponent  SENDER  = (ControlBoxComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 182;
                DEVICE_IPADDRESS  .UpdateValue ( ARGS . Payload  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        object CONNECT_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 193;
                if ( Functions.TestForTrue  ( ( READY)  ) ) 
                    {
                    __context__.SourceCodeLine = 194;
                    COMM . Connect ( ) ; 
                    }
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object DISCONNECT_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 199;
            if ( Functions.TestForTrue  ( ( READY)  ) ) 
                {
                __context__.SourceCodeLine = 200;
                COMM . Disconnect ( ) ; 
                }
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object REINITIALIZE_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 205;
        COMM . Reinitialize ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object IPADDRESS_INPUT_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 210;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IPADDRESS_INPUT != ""))  ) ) 
            {
            __context__.SourceCodeLine = 211;
            MYIPADDRESS  .UpdateValue ( IPADDRESS_INPUT  ) ; 
            }
        
        __context__.SourceCodeLine = 212;
        COMM . SetIPAddress ( MYIPADDRESS .ToString()) ; 
        __context__.SourceCodeLine = 213;
        CONTROL . ProcessIPAddress ( MYIPADDRESS .ToString()) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DEBUG_LEVEL_OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 220;
        COMM . DebugLevel ( (ushort)( DEBUG_LEVEL  .UshortValue )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SENDPASSTHRU_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 227;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PASSTHRU != ""))  ) ) 
            {
            __context__.SourceCodeLine = 228;
            CONTROL . Passthru ( PASSTHRU .ToString()) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object REBOOTCONTROLLER_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 235;
        CONTROL . RebootController ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object REBOOTSYSTEM_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 240;
        CONTROL . RebootSystem ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ALLSCREENON_OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 247;
        CONTROL . AllScreenOn ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ALLSCREENFLASH_OnPush_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 252;
        CONTROL . AllScreenFlash ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ALLSCREENOFF_OnPush_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 257;
        CONTROL . AllScreenOff ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ALLOSDON_OnPush_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 264;
        CONTROL . AllOsdOn ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ALLOSDOFF_OnPush_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 269;
        CONTROL . AllOsdOff ( ) ; 
        
        
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
        
        __context__.SourceCodeLine = 278;
        RESETOUTPUTS (  __context__  ) ; 
        __context__.SourceCodeLine = 280;
        READY = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 282;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IPADDRESS_INPUT != ""))  ) ) 
            {
            __context__.SourceCodeLine = 283;
            MYIPADDRESS  .UpdateValue ( IPADDRESS_INPUT  ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 286;
            MYIPADDRESS  .UpdateValue ( IPADDRESS  ) ; 
            }
        
        __context__.SourceCodeLine = 288;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 290;
        // RegisterEvent( COMM , ONREADYSTATE , ONREADYSTATE ) 
        try { g_criticalSection.Enter(); COMM .OnReadyState  += ONREADYSTATE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 291;
        // RegisterEvent( COMM , ONINITIALIZATIONCHANGE , ONINITIALIZATIONCHANGE ) 
        try { g_criticalSection.Enter(); COMM .OnInitializationChange  += ONINITIALIZATIONCHANGE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 292;
        // RegisterEvent( COMM , ONCOMMUNICATIONCHANGE , ONCOMMUNICATIONCHANGE ) 
        try { g_criticalSection.Enter(); COMM .OnCommunicationChange  += ONCOMMUNICATIONCHANGE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 293;
        // RegisterEvent( COMM , ONDEBUGMESSAGE , ONDEBUGMESSAGE ) 
        try { g_criticalSection.Enter(); COMM .OnDebugMessage  += ONDEBUGMESSAGE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 294;
        // RegisterEvent( CONTROL , ONIPADDRESS , ONIPADDRESS ) 
        try { g_criticalSection.Enter(); CONTROL .OnIPAddress  += ONIPADDRESS; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 296;
        COMM . Configure ( (ushort)( COMMANDPROCESSORID  .Value ), MYIPADDRESS .ToString(), (ushort)( POLLTIME  .Value )) ; 
        __context__.SourceCodeLine = 297;
        CONTROL . Configure ( (ushort)( COMMANDPROCESSORID  .Value )) ; 
        __context__.SourceCodeLine = 298;
        CONTROL . ProcessIPAddress ( MYIPADDRESS .ToString()) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    MYIPADDRESS  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 15, this );
    
    CONNECT = new Crestron.Logos.SplusObjects.DigitalInput( CONNECT__DigitalInput__, this );
    m_DigitalInputList.Add( CONNECT__DigitalInput__, CONNECT );
    
    DISCONNECT = new Crestron.Logos.SplusObjects.DigitalInput( DISCONNECT__DigitalInput__, this );
    m_DigitalInputList.Add( DISCONNECT__DigitalInput__, DISCONNECT );
    
    REINITIALIZE = new Crestron.Logos.SplusObjects.DigitalInput( REINITIALIZE__DigitalInput__, this );
    m_DigitalInputList.Add( REINITIALIZE__DigitalInput__, REINITIALIZE );
    
    DEBUGENABLE = new Crestron.Logos.SplusObjects.DigitalInput( DEBUGENABLE__DigitalInput__, this );
    m_DigitalInputList.Add( DEBUGENABLE__DigitalInput__, DEBUGENABLE );
    
    SENDPASSTHRU = new Crestron.Logos.SplusObjects.DigitalInput( SENDPASSTHRU__DigitalInput__, this );
    m_DigitalInputList.Add( SENDPASSTHRU__DigitalInput__, SENDPASSTHRU );
    
    REBOOTCONTROLLER = new Crestron.Logos.SplusObjects.DigitalInput( REBOOTCONTROLLER__DigitalInput__, this );
    m_DigitalInputList.Add( REBOOTCONTROLLER__DigitalInput__, REBOOTCONTROLLER );
    
    REBOOTSYSTEM = new Crestron.Logos.SplusObjects.DigitalInput( REBOOTSYSTEM__DigitalInput__, this );
    m_DigitalInputList.Add( REBOOTSYSTEM__DigitalInput__, REBOOTSYSTEM );
    
    ALLSCREENON = new Crestron.Logos.SplusObjects.DigitalInput( ALLSCREENON__DigitalInput__, this );
    m_DigitalInputList.Add( ALLSCREENON__DigitalInput__, ALLSCREENON );
    
    ALLSCREENFLASH = new Crestron.Logos.SplusObjects.DigitalInput( ALLSCREENFLASH__DigitalInput__, this );
    m_DigitalInputList.Add( ALLSCREENFLASH__DigitalInput__, ALLSCREENFLASH );
    
    ALLSCREENOFF = new Crestron.Logos.SplusObjects.DigitalInput( ALLSCREENOFF__DigitalInput__, this );
    m_DigitalInputList.Add( ALLSCREENOFF__DigitalInput__, ALLSCREENOFF );
    
    ALLOSDON = new Crestron.Logos.SplusObjects.DigitalInput( ALLOSDON__DigitalInput__, this );
    m_DigitalInputList.Add( ALLOSDON__DigitalInput__, ALLOSDON );
    
    ALLOSDOFF = new Crestron.Logos.SplusObjects.DigitalInput( ALLOSDOFF__DigitalInput__, this );
    m_DigitalInputList.Add( ALLOSDOFF__DigitalInput__, ALLOSDOFF );
    
    ISCOMMUNICATING = new Crestron.Logos.SplusObjects.DigitalOutput( ISCOMMUNICATING__DigitalOutput__, this );
    m_DigitalOutputList.Add( ISCOMMUNICATING__DigitalOutput__, ISCOMMUNICATING );
    
    ISINITIALIZED = new Crestron.Logos.SplusObjects.DigitalOutput( ISINITIALIZED__DigitalOutput__, this );
    m_DigitalOutputList.Add( ISINITIALIZED__DigitalOutput__, ISINITIALIZED );
    
    DEBUG_LEVEL = new Crestron.Logos.SplusObjects.AnalogInput( DEBUG_LEVEL__AnalogSerialInput__, this );
    m_AnalogInputList.Add( DEBUG_LEVEL__AnalogSerialInput__, DEBUG_LEVEL );
    
    IPADDRESS_INPUT = new Crestron.Logos.SplusObjects.StringInput( IPADDRESS_INPUT__AnalogSerialInput__, 15, this );
    m_StringInputList.Add( IPADDRESS_INPUT__AnalogSerialInput__, IPADDRESS_INPUT );
    
    PASSTHRU = new Crestron.Logos.SplusObjects.StringInput( PASSTHRU__AnalogSerialInput__, 500, this );
    m_StringInputList.Add( PASSTHRU__AnalogSerialInput__, PASSTHRU );
    
    DEVICE_IPADDRESS = new Crestron.Logos.SplusObjects.StringOutput( DEVICE_IPADDRESS__AnalogSerialOutput__, this );
    m_StringOutputList.Add( DEVICE_IPADDRESS__AnalogSerialOutput__, DEVICE_IPADDRESS );
    
    COMMANDPROCESSORID = new UShortParameter( COMMANDPROCESSORID__Parameter__, this );
    m_ParameterList.Add( COMMANDPROCESSORID__Parameter__, COMMANDPROCESSORID );
    
    POLLTIME = new UShortParameter( POLLTIME__Parameter__, this );
    m_ParameterList.Add( POLLTIME__Parameter__, POLLTIME );
    
    IPADDRESS = new StringParameter( IPADDRESS__Parameter__, this );
    m_ParameterList.Add( IPADDRESS__Parameter__, IPADDRESS );
    
    
    CONNECT.OnDigitalPush.Add( new InputChangeHandlerWrapper( CONNECT_OnPush_0, true ) );
    DISCONNECT.OnDigitalPush.Add( new InputChangeHandlerWrapper( DISCONNECT_OnPush_1, true ) );
    REINITIALIZE.OnDigitalPush.Add( new InputChangeHandlerWrapper( REINITIALIZE_OnPush_2, true ) );
    IPADDRESS_INPUT.OnSerialChange.Add( new InputChangeHandlerWrapper( IPADDRESS_INPUT_OnChange_3, true ) );
    DEBUG_LEVEL.OnAnalogChange.Add( new InputChangeHandlerWrapper( DEBUG_LEVEL_OnChange_4, true ) );
    SENDPASSTHRU.OnDigitalPush.Add( new InputChangeHandlerWrapper( SENDPASSTHRU_OnPush_5, true ) );
    REBOOTCONTROLLER.OnDigitalPush.Add( new InputChangeHandlerWrapper( REBOOTCONTROLLER_OnPush_6, true ) );
    REBOOTSYSTEM.OnDigitalPush.Add( new InputChangeHandlerWrapper( REBOOTSYSTEM_OnPush_7, true ) );
    ALLSCREENON.OnDigitalPush.Add( new InputChangeHandlerWrapper( ALLSCREENON_OnPush_8, true ) );
    ALLSCREENFLASH.OnDigitalPush.Add( new InputChangeHandlerWrapper( ALLSCREENFLASH_OnPush_9, true ) );
    ALLSCREENOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( ALLSCREENOFF_OnPush_10, true ) );
    ALLOSDON.OnDigitalPush.Add( new InputChangeHandlerWrapper( ALLOSDON_OnPush_11, true ) );
    ALLOSDOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( ALLOSDOFF_OnPush_12, true ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    COMM  = new AVProEdgeMXNetLib.CommandProcessor();
    CONTROL  = new AVProEdgeMXNetLib.Components.ControlBoxComponent();
    
    
}

public UserModuleClass_AVPRO_EDGE_MXNET_COMMANDPROCESSOR_V1_2 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint CONNECT__DigitalInput__ = 0;
const uint DISCONNECT__DigitalInput__ = 1;
const uint REINITIALIZE__DigitalInput__ = 2;
const uint DEBUGENABLE__DigitalInput__ = 3;
const uint SENDPASSTHRU__DigitalInput__ = 4;
const uint REBOOTCONTROLLER__DigitalInput__ = 5;
const uint REBOOTSYSTEM__DigitalInput__ = 6;
const uint ALLSCREENON__DigitalInput__ = 7;
const uint ALLSCREENFLASH__DigitalInput__ = 8;
const uint ALLSCREENOFF__DigitalInput__ = 9;
const uint ALLOSDON__DigitalInput__ = 10;
const uint ALLOSDOFF__DigitalInput__ = 11;
const uint DEBUG_LEVEL__AnalogSerialInput__ = 0;
const uint IPADDRESS_INPUT__AnalogSerialInput__ = 1;
const uint PASSTHRU__AnalogSerialInput__ = 2;
const uint ISCOMMUNICATING__DigitalOutput__ = 0;
const uint ISINITIALIZED__DigitalOutput__ = 1;
const uint DEVICE_IPADDRESS__AnalogSerialOutput__ = 0;
const uint COMMANDPROCESSORID__Parameter__ = 10;
const uint IPADDRESS__Parameter__ = 11;
const uint POLLTIME__Parameter__ = 12;

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
