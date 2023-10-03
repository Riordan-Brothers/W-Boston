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

namespace UserModule_AVPRO_EDGE_MXNET_DESTINATIONROUTER_V1_2
{
    public class UserModuleClass_AVPRO_EDGE_MXNET_DESTINATIONROUTER_V1_2 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput TAKEROUTE;
        Crestron.Logos.SplusObjects.DigitalInput ENABLEVIDEO;
        Crestron.Logos.SplusObjects.DigitalInput ENABLEAUDIO;
        Crestron.Logos.SplusObjects.DigitalInput ENABLEUSB;
        Crestron.Logos.SplusObjects.DigitalInput ENABLEINFRARED;
        Crestron.Logos.SplusObjects.DigitalInput ENABLESERIAL;
        Crestron.Logos.SplusObjects.AnalogInput SOURCEROUTE;
        Crestron.Logos.SplusObjects.DigitalOutput ISINITIALIZED;
        Crestron.Logos.SplusObjects.AnalogOutput SOURCEVIDEOFB;
        Crestron.Logos.SplusObjects.AnalogOutput SOURCEAUDIOFB;
        Crestron.Logos.SplusObjects.AnalogOutput SOURCEUSBFB;
        Crestron.Logos.SplusObjects.AnalogOutput SOURCEINFRAREDFB;
        Crestron.Logos.SplusObjects.AnalogOutput SOURCESERIALFB;
        UShortParameter COMMANDPROCESSORID;
        UShortParameter MATRIXDESTINATIONINDEX;
        StringParameter MULTIROUTEGROUPIDLIST;
        AVProEdgeMXNetLib.Components.DestinationRouterComponent ROUTER;
        private void RESETOUTPUTS (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 112;
            ISINITIALIZED  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 116;
            SOURCEVIDEOFB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 117;
            SOURCEAUDIOFB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 118;
            SOURCEUSBFB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 119;
            SOURCEINFRAREDFB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 120;
            SOURCESERIALFB  .Value = (ushort) ( 0 ) ; 
            
            }
            
        public void ONINITIALIZE ( object __sender__ /*AVProEdgeMXNetLib.Components.DestinationRouterComponent SENDER */, AVProEdgeMXNetLib.EventArguments.DigEventArgs ARGS ) 
            { 
            DestinationRouterComponent  SENDER  = (DestinationRouterComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 127;
                ISINITIALIZED  .Value = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONSOURCEVIDEO ( object __sender__ /*AVProEdgeMXNetLib.Components.DestinationRouterComponent SENDER */, AVProEdgeMXNetLib.EventArguments.AnaEventArgs ARGS ) 
            { 
            DestinationRouterComponent  SENDER  = (DestinationRouterComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 132;
                SOURCEVIDEOFB  .Value = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONSOURCEAUDIO ( object __sender__ /*AVProEdgeMXNetLib.Components.DestinationRouterComponent SENDER */, AVProEdgeMXNetLib.EventArguments.AnaEventArgs ARGS ) 
            { 
            DestinationRouterComponent  SENDER  = (DestinationRouterComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 137;
                SOURCEAUDIOFB  .Value = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONSOURCEUSB ( object __sender__ /*AVProEdgeMXNetLib.Components.DestinationRouterComponent SENDER */, AVProEdgeMXNetLib.EventArguments.AnaEventArgs ARGS ) 
            { 
            DestinationRouterComponent  SENDER  = (DestinationRouterComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 142;
                SOURCEUSBFB  .Value = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONSOURCEINFRARED ( object __sender__ /*AVProEdgeMXNetLib.Components.DestinationRouterComponent SENDER */, AVProEdgeMXNetLib.EventArguments.AnaEventArgs ARGS ) 
            { 
            DestinationRouterComponent  SENDER  = (DestinationRouterComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 147;
                SOURCEINFRAREDFB  .Value = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONSOURCESERIAL ( object __sender__ /*AVProEdgeMXNetLib.Components.DestinationRouterComponent SENDER */, AVProEdgeMXNetLib.EventArguments.AnaEventArgs ARGS ) 
            { 
            DestinationRouterComponent  SENDER  = (DestinationRouterComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 152;
                SOURCESERIALFB  .Value = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        object SOURCEROUTE_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 164;
                ROUTER . SetRoute ( (ushort)( SOURCEROUTE  .UshortValue )) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object TAKEROUTE_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 169;
            ROUTER . TakeRoute ( ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object ENABLEVIDEO_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 176;
        ROUTER . SetEnableVideo ( (ushort)( 1 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ENABLEVIDEO_OnRelease_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 181;
        ROUTER . SetEnableVideo ( (ushort)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ENABLEAUDIO_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 186;
        ROUTER . SetEnableAudio ( (ushort)( 1 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ENABLEAUDIO_OnRelease_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 191;
        ROUTER . SetEnableAudio ( (ushort)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ENABLEUSB_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 196;
        ROUTER . SetEnableUsb ( (ushort)( 1 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ENABLEUSB_OnRelease_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 201;
        ROUTER . SetEnableUsb ( (ushort)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ENABLEINFRARED_OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 206;
        ROUTER . SetEnableInfrared ( (ushort)( 1 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ENABLEINFRARED_OnRelease_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 211;
        ROUTER . SetEnableInfrared ( (ushort)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ENABLESERIAL_OnPush_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 216;
        ROUTER . SetEnableSerial ( (ushort)( 1 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ENABLESERIAL_OnRelease_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 221;
        ROUTER . SetEnableSerial ( (ushort)( 0 )) ; 
        
        
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
        
        __context__.SourceCodeLine = 230;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 232;
        RESETOUTPUTS (  __context__  ) ; 
        __context__.SourceCodeLine = 234;
        // RegisterEvent( ROUTER , ONINITIALIZE , ONINITIALIZE ) 
        try { g_criticalSection.Enter(); ROUTER .OnInitialize  += ONINITIALIZE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 235;
        // RegisterEvent( ROUTER , ONSOURCEVIDEO , ONSOURCEVIDEO ) 
        try { g_criticalSection.Enter(); ROUTER .OnSourceVideo  += ONSOURCEVIDEO; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 236;
        // RegisterEvent( ROUTER , ONSOURCEAUDIO , ONSOURCEAUDIO ) 
        try { g_criticalSection.Enter(); ROUTER .OnSourceAudio  += ONSOURCEAUDIO; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 237;
        // RegisterEvent( ROUTER , ONSOURCEUSB , ONSOURCEUSB ) 
        try { g_criticalSection.Enter(); ROUTER .OnSourceUsb  += ONSOURCEUSB; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 238;
        // RegisterEvent( ROUTER , ONSOURCEINFRARED , ONSOURCEINFRARED ) 
        try { g_criticalSection.Enter(); ROUTER .OnSourceInfrared  += ONSOURCEINFRARED; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 239;
        // RegisterEvent( ROUTER , ONSOURCESERIAL , ONSOURCESERIAL ) 
        try { g_criticalSection.Enter(); ROUTER .OnSourceSerial  += ONSOURCESERIAL; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 241;
        ROUTER . Configure ( (ushort)( COMMANDPROCESSORID  .Value ), (ushort)( MATRIXDESTINATIONINDEX  .Value ), MULTIROUTEGROUPIDLIST  .ToString()) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    TAKEROUTE = new Crestron.Logos.SplusObjects.DigitalInput( TAKEROUTE__DigitalInput__, this );
    m_DigitalInputList.Add( TAKEROUTE__DigitalInput__, TAKEROUTE );
    
    ENABLEVIDEO = new Crestron.Logos.SplusObjects.DigitalInput( ENABLEVIDEO__DigitalInput__, this );
    m_DigitalInputList.Add( ENABLEVIDEO__DigitalInput__, ENABLEVIDEO );
    
    ENABLEAUDIO = new Crestron.Logos.SplusObjects.DigitalInput( ENABLEAUDIO__DigitalInput__, this );
    m_DigitalInputList.Add( ENABLEAUDIO__DigitalInput__, ENABLEAUDIO );
    
    ENABLEUSB = new Crestron.Logos.SplusObjects.DigitalInput( ENABLEUSB__DigitalInput__, this );
    m_DigitalInputList.Add( ENABLEUSB__DigitalInput__, ENABLEUSB );
    
    ENABLEINFRARED = new Crestron.Logos.SplusObjects.DigitalInput( ENABLEINFRARED__DigitalInput__, this );
    m_DigitalInputList.Add( ENABLEINFRARED__DigitalInput__, ENABLEINFRARED );
    
    ENABLESERIAL = new Crestron.Logos.SplusObjects.DigitalInput( ENABLESERIAL__DigitalInput__, this );
    m_DigitalInputList.Add( ENABLESERIAL__DigitalInput__, ENABLESERIAL );
    
    ISINITIALIZED = new Crestron.Logos.SplusObjects.DigitalOutput( ISINITIALIZED__DigitalOutput__, this );
    m_DigitalOutputList.Add( ISINITIALIZED__DigitalOutput__, ISINITIALIZED );
    
    SOURCEROUTE = new Crestron.Logos.SplusObjects.AnalogInput( SOURCEROUTE__AnalogSerialInput__, this );
    m_AnalogInputList.Add( SOURCEROUTE__AnalogSerialInput__, SOURCEROUTE );
    
    SOURCEVIDEOFB = new Crestron.Logos.SplusObjects.AnalogOutput( SOURCEVIDEOFB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( SOURCEVIDEOFB__AnalogSerialOutput__, SOURCEVIDEOFB );
    
    SOURCEAUDIOFB = new Crestron.Logos.SplusObjects.AnalogOutput( SOURCEAUDIOFB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( SOURCEAUDIOFB__AnalogSerialOutput__, SOURCEAUDIOFB );
    
    SOURCEUSBFB = new Crestron.Logos.SplusObjects.AnalogOutput( SOURCEUSBFB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( SOURCEUSBFB__AnalogSerialOutput__, SOURCEUSBFB );
    
    SOURCEINFRAREDFB = new Crestron.Logos.SplusObjects.AnalogOutput( SOURCEINFRAREDFB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( SOURCEINFRAREDFB__AnalogSerialOutput__, SOURCEINFRAREDFB );
    
    SOURCESERIALFB = new Crestron.Logos.SplusObjects.AnalogOutput( SOURCESERIALFB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( SOURCESERIALFB__AnalogSerialOutput__, SOURCESERIALFB );
    
    COMMANDPROCESSORID = new UShortParameter( COMMANDPROCESSORID__Parameter__, this );
    m_ParameterList.Add( COMMANDPROCESSORID__Parameter__, COMMANDPROCESSORID );
    
    MATRIXDESTINATIONINDEX = new UShortParameter( MATRIXDESTINATIONINDEX__Parameter__, this );
    m_ParameterList.Add( MATRIXDESTINATIONINDEX__Parameter__, MATRIXDESTINATIONINDEX );
    
    MULTIROUTEGROUPIDLIST = new StringParameter( MULTIROUTEGROUPIDLIST__Parameter__, this );
    m_ParameterList.Add( MULTIROUTEGROUPIDLIST__Parameter__, MULTIROUTEGROUPIDLIST );
    
    
    SOURCEROUTE.OnAnalogChange.Add( new InputChangeHandlerWrapper( SOURCEROUTE_OnChange_0, true ) );
    TAKEROUTE.OnDigitalPush.Add( new InputChangeHandlerWrapper( TAKEROUTE_OnPush_1, true ) );
    ENABLEVIDEO.OnDigitalPush.Add( new InputChangeHandlerWrapper( ENABLEVIDEO_OnPush_2, true ) );
    ENABLEVIDEO.OnDigitalRelease.Add( new InputChangeHandlerWrapper( ENABLEVIDEO_OnRelease_3, true ) );
    ENABLEAUDIO.OnDigitalPush.Add( new InputChangeHandlerWrapper( ENABLEAUDIO_OnPush_4, true ) );
    ENABLEAUDIO.OnDigitalRelease.Add( new InputChangeHandlerWrapper( ENABLEAUDIO_OnRelease_5, true ) );
    ENABLEUSB.OnDigitalPush.Add( new InputChangeHandlerWrapper( ENABLEUSB_OnPush_6, true ) );
    ENABLEUSB.OnDigitalRelease.Add( new InputChangeHandlerWrapper( ENABLEUSB_OnRelease_7, true ) );
    ENABLEINFRARED.OnDigitalPush.Add( new InputChangeHandlerWrapper( ENABLEINFRARED_OnPush_8, true ) );
    ENABLEINFRARED.OnDigitalRelease.Add( new InputChangeHandlerWrapper( ENABLEINFRARED_OnRelease_9, true ) );
    ENABLESERIAL.OnDigitalPush.Add( new InputChangeHandlerWrapper( ENABLESERIAL_OnPush_10, true ) );
    ENABLESERIAL.OnDigitalRelease.Add( new InputChangeHandlerWrapper( ENABLESERIAL_OnRelease_11, true ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    ROUTER  = new AVProEdgeMXNetLib.Components.DestinationRouterComponent();
    
    
}

public UserModuleClass_AVPRO_EDGE_MXNET_DESTINATIONROUTER_V1_2 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint TAKEROUTE__DigitalInput__ = 0;
const uint ENABLEVIDEO__DigitalInput__ = 1;
const uint ENABLEAUDIO__DigitalInput__ = 2;
const uint ENABLEUSB__DigitalInput__ = 3;
const uint ENABLEINFRARED__DigitalInput__ = 4;
const uint ENABLESERIAL__DigitalInput__ = 5;
const uint SOURCEROUTE__AnalogSerialInput__ = 0;
const uint ISINITIALIZED__DigitalOutput__ = 0;
const uint SOURCEVIDEOFB__AnalogSerialOutput__ = 0;
const uint SOURCEAUDIOFB__AnalogSerialOutput__ = 1;
const uint SOURCEUSBFB__AnalogSerialOutput__ = 2;
const uint SOURCEINFRAREDFB__AnalogSerialOutput__ = 3;
const uint SOURCESERIALFB__AnalogSerialOutput__ = 4;
const uint COMMANDPROCESSORID__Parameter__ = 10;
const uint MATRIXDESTINATIONINDEX__Parameter__ = 11;
const uint MULTIROUTEGROUPIDLIST__Parameter__ = 12;

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
