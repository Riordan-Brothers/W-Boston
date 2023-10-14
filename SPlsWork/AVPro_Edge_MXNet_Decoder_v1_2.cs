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

namespace UserModule_AVPRO_EDGE_MXNET_DECODER_V1_2
{
    public class UserModuleClass_AVPRO_EDGE_MXNET_DECODER_V1_2 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput REBOOT;
        Crestron.Logos.SplusObjects.DigitalInput SCREENON;
        Crestron.Logos.SplusObjects.DigitalInput SCREENFLASH;
        Crestron.Logos.SplusObjects.DigitalInput SCREENOFF;
        Crestron.Logos.SplusObjects.DigitalInput OSDON;
        Crestron.Logos.SplusObjects.DigitalInput OSDOFF;
        Crestron.Logos.SplusObjects.DigitalInput HOTPLUGRESET;
        Crestron.Logos.SplusObjects.AnalogInput RESOLUTIONSET;
        Crestron.Logos.SplusObjects.DigitalOutput ISINITIALIZED;
        Crestron.Logos.SplusObjects.DigitalOutput ISONLINE;
        Crestron.Logos.SplusObjects.DigitalOutput SCREENONFB;
        Crestron.Logos.SplusObjects.DigitalOutput SCREENFLASHFB;
        Crestron.Logos.SplusObjects.DigitalOutput SCREENOFFFB;
        Crestron.Logos.SplusObjects.DigitalOutput OSDONFB;
        Crestron.Logos.SplusObjects.DigitalOutput OSDOFFFB;
        Crestron.Logos.SplusObjects.DigitalOutput HOTPLUGFB;
        Crestron.Logos.SplusObjects.AnalogOutput RESOLUTIONFB;
        Crestron.Logos.SplusObjects.AnalogOutput VIDEOWALLCOUNTFB;
        Crestron.Logos.SplusObjects.StringOutput CONNECTIONRATINGFB;
        Crestron.Logos.SplusObjects.StringOutput RESANDTIMEFB;
        Crestron.Logos.SplusObjects.StringOutput COLORSPACEFB;
        Crestron.Logos.SplusObjects.StringOutput BITDEPTHFB;
        Crestron.Logos.SplusObjects.StringOutput HDRFB;
        Crestron.Logos.SplusObjects.StringOutput HDCPFB;
        Crestron.Logos.SplusObjects.StringOutput AUDIOFORMATFB;
        Crestron.Logos.SplusObjects.StringOutput NETWORKCONNECTIONFB;
        UShortParameter COMMANDPROCESSORID;
        StringParameter DEVICEID;
        UShortParameter INDEX;
        AVProEdgeMXNetLib.Components.DecoderComponent DECODER;
        private void RESETOUTPUTS (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 131;
            ISINITIALIZED  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 132;
            ISONLINE  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 133;
            SCREENONFB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 134;
            SCREENFLASHFB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 135;
            SCREENOFFFB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 136;
            OSDONFB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 137;
            OSDOFFFB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 138;
            HOTPLUGFB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 142;
            RESOLUTIONFB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 143;
            VIDEOWALLCOUNTFB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 144;
            CONNECTIONRATINGFB  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 148;
            RESANDTIMEFB  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 149;
            COLORSPACEFB  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 150;
            BITDEPTHFB  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 151;
            HDRFB  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 152;
            HDCPFB  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 153;
            AUDIOFORMATFB  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 154;
            NETWORKCONNECTIONFB  .UpdateValue ( ""  ) ; 
            
            }
            
        public void ONINITIALIZE ( object __sender__ /*AVProEdgeMXNetLib.Components.DecoderComponent SENDER */, AVProEdgeMXNetLib.EventArguments.DigEventArgs ARGS ) 
            { 
            DecoderComponent  SENDER  = (DecoderComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 161;
                ISINITIALIZED  .Value = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONONLINE ( object __sender__ /*AVProEdgeMXNetLib.Components.DecoderComponent SENDER */, AVProEdgeMXNetLib.EventArguments.DigEventArgs ARGS ) 
            { 
            DecoderComponent  SENDER  = (DecoderComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 166;
                ISONLINE  .Value = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONSCREEN ( object __sender__ /*AVProEdgeMXNetLib.Components.DecoderComponent SENDER */, AVProEdgeMXNetLib.EventArguments.AnaEventArgs ARGS ) 
            { 
            DecoderComponent  SENDER  = (DecoderComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 176;
                SCREENONFB  .Value = (ushort) ( Functions.BoolToInt (ARGS.Payload == 0) ) ; 
                __context__.SourceCodeLine = 177;
                SCREENFLASHFB  .Value = (ushort) ( Functions.BoolToInt (ARGS.Payload == 1) ) ; 
                __context__.SourceCodeLine = 178;
                SCREENOFFFB  .Value = (ushort) ( Functions.BoolToInt (ARGS.Payload == 2) ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONOSDMODE ( object __sender__ /*AVProEdgeMXNetLib.Components.DecoderComponent SENDER */, AVProEdgeMXNetLib.EventArguments.AnaEventArgs ARGS ) 
            { 
            DecoderComponent  SENDER  = (DecoderComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 187;
                OSDONFB  .Value = (ushort) ( Functions.BoolToInt (ARGS.Payload == 1) ) ; 
                __context__.SourceCodeLine = 188;
                OSDOFFFB  .Value = (ushort) ( Functions.BoolToInt (ARGS.Payload == 0) ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONRESOLUTION ( object __sender__ /*AVProEdgeMXNetLib.Components.DecoderComponent SENDER */, AVProEdgeMXNetLib.EventArguments.AnaEventArgs ARGS ) 
            { 
            DecoderComponent  SENDER  = (DecoderComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 193;
                RESOLUTIONFB  .Value = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONHOTPLUG ( object __sender__ /*AVProEdgeMXNetLib.Components.DecoderComponent SENDER */, AVProEdgeMXNetLib.EventArguments.DigEventArgs ARGS ) 
            { 
            DecoderComponent  SENDER  = (DecoderComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 198;
                HOTPLUGFB  .Value = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONCONNECTIONRATING ( object __sender__ /*AVProEdgeMXNetLib.Components.DecoderComponent SENDER */, AVProEdgeMXNetLib.EventArguments.SerEventArgs ARGS ) 
            { 
            DecoderComponent  SENDER  = (DecoderComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 203;
                CONNECTIONRATINGFB  .UpdateValue ( ARGS . Payload  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONRESANDTIMING ( object __sender__ /*AVProEdgeMXNetLib.Components.DecoderComponent SENDER */, AVProEdgeMXNetLib.EventArguments.SerEventArgs ARGS ) 
            { 
            DecoderComponent  SENDER  = (DecoderComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 208;
                RESANDTIMEFB  .UpdateValue ( ARGS . Payload  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONCOLORSPACE ( object __sender__ /*AVProEdgeMXNetLib.Components.DecoderComponent SENDER */, AVProEdgeMXNetLib.EventArguments.SerEventArgs ARGS ) 
            { 
            DecoderComponent  SENDER  = (DecoderComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 213;
                COLORSPACEFB  .UpdateValue ( ARGS . Payload  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONBITDEPTH ( object __sender__ /*AVProEdgeMXNetLib.Components.DecoderComponent SENDER */, AVProEdgeMXNetLib.EventArguments.SerEventArgs ARGS ) 
            { 
            DecoderComponent  SENDER  = (DecoderComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 218;
                BITDEPTHFB  .UpdateValue ( ARGS . Payload  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONHDR ( object __sender__ /*AVProEdgeMXNetLib.Components.DecoderComponent SENDER */, AVProEdgeMXNetLib.EventArguments.SerEventArgs ARGS ) 
            { 
            DecoderComponent  SENDER  = (DecoderComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 223;
                HDRFB  .UpdateValue ( ARGS . Payload  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONHDCP ( object __sender__ /*AVProEdgeMXNetLib.Components.DecoderComponent SENDER */, AVProEdgeMXNetLib.EventArguments.SerEventArgs ARGS ) 
            { 
            DecoderComponent  SENDER  = (DecoderComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 228;
                HDCPFB  .UpdateValue ( ARGS . Payload  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONAUDIOFORMAT ( object __sender__ /*AVProEdgeMXNetLib.Components.DecoderComponent SENDER */, AVProEdgeMXNetLib.EventArguments.SerEventArgs ARGS ) 
            { 
            DecoderComponent  SENDER  = (DecoderComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 233;
                AUDIOFORMATFB  .UpdateValue ( ARGS . Payload  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONNETWORKCONNECTION ( object __sender__ /*AVProEdgeMXNetLib.Components.DecoderComponent SENDER */, AVProEdgeMXNetLib.EventArguments.SerEventArgs ARGS ) 
            { 
            DecoderComponent  SENDER  = (DecoderComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 238;
                NETWORKCONNECTIONFB  .UpdateValue ( ARGS . Payload  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONVIDEOWALLCOUNT ( object __sender__ /*AVProEdgeMXNetLib.Components.DecoderComponent SENDER */, AVProEdgeMXNetLib.EventArguments.AnaEventArgs ARGS ) 
            { 
            DecoderComponent  SENDER  = (DecoderComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 243;
                VIDEOWALLCOUNTFB  .Value = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        object REBOOT_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 254;
                DECODER . SetReboot ( ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object SCREENON_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 261;
            DECODER . SetScreenOn ( ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object SCREENFLASH_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 266;
        DECODER . SetScreenFlash ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SCREENOFF_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 271;
        DECODER . SetScreenOff ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object OSDON_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 278;
        DECODER . SetOsdOn ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object OSDOFF_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 283;
        DECODER . SetOsdOff ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HOTPLUGRESET_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 290;
        DECODER . SetHotplugReset ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RESOLUTIONSET_OnChange_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 297;
        DECODER . SetResolution ( (short)( RESOLUTIONSET  .ShortValue )) ; 
        
        
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
        
        __context__.SourceCodeLine = 306;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 308;
        RESETOUTPUTS (  __context__  ) ; 
        __context__.SourceCodeLine = 310;
        // RegisterEvent( DECODER , ONINITIALIZE , ONINITIALIZE ) 
        try { g_criticalSection.Enter(); DECODER .OnInitialize  += ONINITIALIZE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 311;
        // RegisterEvent( DECODER , ONONLINE , ONONLINE ) 
        try { g_criticalSection.Enter(); DECODER .OnOnline  += ONONLINE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 312;
        // RegisterEvent( DECODER , ONSCREEN , ONSCREEN ) 
        try { g_criticalSection.Enter(); DECODER .OnScreen  += ONSCREEN; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 313;
        // RegisterEvent( DECODER , ONOSDMODE , ONOSDMODE ) 
        try { g_criticalSection.Enter(); DECODER .OnOsdMode  += ONOSDMODE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 314;
        // RegisterEvent( DECODER , ONRESOLUTION , ONRESOLUTION ) 
        try { g_criticalSection.Enter(); DECODER .OnResolution  += ONRESOLUTION; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 315;
        // RegisterEvent( DECODER , ONHOTPLUG , ONHOTPLUG ) 
        try { g_criticalSection.Enter(); DECODER .OnHotPlug  += ONHOTPLUG; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 316;
        // RegisterEvent( DECODER , ONCONNECTIONRATING , ONCONNECTIONRATING ) 
        try { g_criticalSection.Enter(); DECODER .OnConnectionRating  += ONCONNECTIONRATING; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 317;
        // RegisterEvent( DECODER , ONRESANDTIMING , ONRESANDTIMING ) 
        try { g_criticalSection.Enter(); DECODER .OnResAndTiming  += ONRESANDTIMING; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 318;
        // RegisterEvent( DECODER , ONCOLORSPACE , ONCOLORSPACE ) 
        try { g_criticalSection.Enter(); DECODER .OnColorspace  += ONCOLORSPACE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 319;
        // RegisterEvent( DECODER , ONBITDEPTH , ONBITDEPTH ) 
        try { g_criticalSection.Enter(); DECODER .OnBitdepth  += ONBITDEPTH; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 320;
        // RegisterEvent( DECODER , ONHDR , ONHDR ) 
        try { g_criticalSection.Enter(); DECODER .OnHdr  += ONHDR; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 321;
        // RegisterEvent( DECODER , ONHDCP , ONHDCP ) 
        try { g_criticalSection.Enter(); DECODER .OnHdcp  += ONHDCP; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 322;
        // RegisterEvent( DECODER , ONAUDIOFORMAT , ONAUDIOFORMAT ) 
        try { g_criticalSection.Enter(); DECODER .OnAudioFormat  += ONAUDIOFORMAT; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 323;
        // RegisterEvent( DECODER , ONNETWORKCONNECTION , ONNETWORKCONNECTION ) 
        try { g_criticalSection.Enter(); DECODER .OnNetworkConnection  += ONNETWORKCONNECTION; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 324;
        // RegisterEvent( DECODER , ONVIDEOWALLCOUNT , ONVIDEOWALLCOUNT ) 
        try { g_criticalSection.Enter(); DECODER .OnVideoWallCount  += ONVIDEOWALLCOUNT; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 326;
        DECODER . Configure ( (ushort)( COMMANDPROCESSORID  .Value ), DEVICEID  .ToString(), (ushort)( INDEX  .Value )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    REBOOT = new Crestron.Logos.SplusObjects.DigitalInput( REBOOT__DigitalInput__, this );
    m_DigitalInputList.Add( REBOOT__DigitalInput__, REBOOT );
    
    SCREENON = new Crestron.Logos.SplusObjects.DigitalInput( SCREENON__DigitalInput__, this );
    m_DigitalInputList.Add( SCREENON__DigitalInput__, SCREENON );
    
    SCREENFLASH = new Crestron.Logos.SplusObjects.DigitalInput( SCREENFLASH__DigitalInput__, this );
    m_DigitalInputList.Add( SCREENFLASH__DigitalInput__, SCREENFLASH );
    
    SCREENOFF = new Crestron.Logos.SplusObjects.DigitalInput( SCREENOFF__DigitalInput__, this );
    m_DigitalInputList.Add( SCREENOFF__DigitalInput__, SCREENOFF );
    
    OSDON = new Crestron.Logos.SplusObjects.DigitalInput( OSDON__DigitalInput__, this );
    m_DigitalInputList.Add( OSDON__DigitalInput__, OSDON );
    
    OSDOFF = new Crestron.Logos.SplusObjects.DigitalInput( OSDOFF__DigitalInput__, this );
    m_DigitalInputList.Add( OSDOFF__DigitalInput__, OSDOFF );
    
    HOTPLUGRESET = new Crestron.Logos.SplusObjects.DigitalInput( HOTPLUGRESET__DigitalInput__, this );
    m_DigitalInputList.Add( HOTPLUGRESET__DigitalInput__, HOTPLUGRESET );
    
    ISINITIALIZED = new Crestron.Logos.SplusObjects.DigitalOutput( ISINITIALIZED__DigitalOutput__, this );
    m_DigitalOutputList.Add( ISINITIALIZED__DigitalOutput__, ISINITIALIZED );
    
    ISONLINE = new Crestron.Logos.SplusObjects.DigitalOutput( ISONLINE__DigitalOutput__, this );
    m_DigitalOutputList.Add( ISONLINE__DigitalOutput__, ISONLINE );
    
    SCREENONFB = new Crestron.Logos.SplusObjects.DigitalOutput( SCREENONFB__DigitalOutput__, this );
    m_DigitalOutputList.Add( SCREENONFB__DigitalOutput__, SCREENONFB );
    
    SCREENFLASHFB = new Crestron.Logos.SplusObjects.DigitalOutput( SCREENFLASHFB__DigitalOutput__, this );
    m_DigitalOutputList.Add( SCREENFLASHFB__DigitalOutput__, SCREENFLASHFB );
    
    SCREENOFFFB = new Crestron.Logos.SplusObjects.DigitalOutput( SCREENOFFFB__DigitalOutput__, this );
    m_DigitalOutputList.Add( SCREENOFFFB__DigitalOutput__, SCREENOFFFB );
    
    OSDONFB = new Crestron.Logos.SplusObjects.DigitalOutput( OSDONFB__DigitalOutput__, this );
    m_DigitalOutputList.Add( OSDONFB__DigitalOutput__, OSDONFB );
    
    OSDOFFFB = new Crestron.Logos.SplusObjects.DigitalOutput( OSDOFFFB__DigitalOutput__, this );
    m_DigitalOutputList.Add( OSDOFFFB__DigitalOutput__, OSDOFFFB );
    
    HOTPLUGFB = new Crestron.Logos.SplusObjects.DigitalOutput( HOTPLUGFB__DigitalOutput__, this );
    m_DigitalOutputList.Add( HOTPLUGFB__DigitalOutput__, HOTPLUGFB );
    
    RESOLUTIONSET = new Crestron.Logos.SplusObjects.AnalogInput( RESOLUTIONSET__AnalogSerialInput__, this );
    m_AnalogInputList.Add( RESOLUTIONSET__AnalogSerialInput__, RESOLUTIONSET );
    
    RESOLUTIONFB = new Crestron.Logos.SplusObjects.AnalogOutput( RESOLUTIONFB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( RESOLUTIONFB__AnalogSerialOutput__, RESOLUTIONFB );
    
    VIDEOWALLCOUNTFB = new Crestron.Logos.SplusObjects.AnalogOutput( VIDEOWALLCOUNTFB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( VIDEOWALLCOUNTFB__AnalogSerialOutput__, VIDEOWALLCOUNTFB );
    
    CONNECTIONRATINGFB = new Crestron.Logos.SplusObjects.StringOutput( CONNECTIONRATINGFB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( CONNECTIONRATINGFB__AnalogSerialOutput__, CONNECTIONRATINGFB );
    
    RESANDTIMEFB = new Crestron.Logos.SplusObjects.StringOutput( RESANDTIMEFB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( RESANDTIMEFB__AnalogSerialOutput__, RESANDTIMEFB );
    
    COLORSPACEFB = new Crestron.Logos.SplusObjects.StringOutput( COLORSPACEFB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( COLORSPACEFB__AnalogSerialOutput__, COLORSPACEFB );
    
    BITDEPTHFB = new Crestron.Logos.SplusObjects.StringOutput( BITDEPTHFB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( BITDEPTHFB__AnalogSerialOutput__, BITDEPTHFB );
    
    HDRFB = new Crestron.Logos.SplusObjects.StringOutput( HDRFB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( HDRFB__AnalogSerialOutput__, HDRFB );
    
    HDCPFB = new Crestron.Logos.SplusObjects.StringOutput( HDCPFB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( HDCPFB__AnalogSerialOutput__, HDCPFB );
    
    AUDIOFORMATFB = new Crestron.Logos.SplusObjects.StringOutput( AUDIOFORMATFB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( AUDIOFORMATFB__AnalogSerialOutput__, AUDIOFORMATFB );
    
    NETWORKCONNECTIONFB = new Crestron.Logos.SplusObjects.StringOutput( NETWORKCONNECTIONFB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( NETWORKCONNECTIONFB__AnalogSerialOutput__, NETWORKCONNECTIONFB );
    
    COMMANDPROCESSORID = new UShortParameter( COMMANDPROCESSORID__Parameter__, this );
    m_ParameterList.Add( COMMANDPROCESSORID__Parameter__, COMMANDPROCESSORID );
    
    INDEX = new UShortParameter( INDEX__Parameter__, this );
    m_ParameterList.Add( INDEX__Parameter__, INDEX );
    
    DEVICEID = new StringParameter( DEVICEID__Parameter__, this );
    m_ParameterList.Add( DEVICEID__Parameter__, DEVICEID );
    
    
    REBOOT.OnDigitalPush.Add( new InputChangeHandlerWrapper( REBOOT_OnPush_0, true ) );
    SCREENON.OnDigitalPush.Add( new InputChangeHandlerWrapper( SCREENON_OnPush_1, true ) );
    SCREENFLASH.OnDigitalPush.Add( new InputChangeHandlerWrapper( SCREENFLASH_OnPush_2, true ) );
    SCREENOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( SCREENOFF_OnPush_3, true ) );
    OSDON.OnDigitalPush.Add( new InputChangeHandlerWrapper( OSDON_OnPush_4, true ) );
    OSDOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( OSDOFF_OnPush_5, true ) );
    HOTPLUGRESET.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOTPLUGRESET_OnPush_6, true ) );
    RESOLUTIONSET.OnAnalogChange.Add( new InputChangeHandlerWrapper( RESOLUTIONSET_OnChange_7, true ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    DECODER  = new AVProEdgeMXNetLib.Components.DecoderComponent();
    
    
}

public UserModuleClass_AVPRO_EDGE_MXNET_DECODER_V1_2 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint REBOOT__DigitalInput__ = 0;
const uint SCREENON__DigitalInput__ = 1;
const uint SCREENFLASH__DigitalInput__ = 2;
const uint SCREENOFF__DigitalInput__ = 3;
const uint OSDON__DigitalInput__ = 4;
const uint OSDOFF__DigitalInput__ = 5;
const uint HOTPLUGRESET__DigitalInput__ = 6;
const uint RESOLUTIONSET__AnalogSerialInput__ = 0;
const uint ISINITIALIZED__DigitalOutput__ = 0;
const uint ISONLINE__DigitalOutput__ = 1;
const uint SCREENONFB__DigitalOutput__ = 2;
const uint SCREENFLASHFB__DigitalOutput__ = 3;
const uint SCREENOFFFB__DigitalOutput__ = 4;
const uint OSDONFB__DigitalOutput__ = 5;
const uint OSDOFFFB__DigitalOutput__ = 6;
const uint HOTPLUGFB__DigitalOutput__ = 7;
const uint RESOLUTIONFB__AnalogSerialOutput__ = 0;
const uint VIDEOWALLCOUNTFB__AnalogSerialOutput__ = 1;
const uint CONNECTIONRATINGFB__AnalogSerialOutput__ = 2;
const uint RESANDTIMEFB__AnalogSerialOutput__ = 3;
const uint COLORSPACEFB__AnalogSerialOutput__ = 4;
const uint BITDEPTHFB__AnalogSerialOutput__ = 5;
const uint HDRFB__AnalogSerialOutput__ = 6;
const uint HDCPFB__AnalogSerialOutput__ = 7;
const uint AUDIOFORMATFB__AnalogSerialOutput__ = 8;
const uint NETWORKCONNECTIONFB__AnalogSerialOutput__ = 9;
const uint COMMANDPROCESSORID__Parameter__ = 10;
const uint DEVICEID__Parameter__ = 11;
const uint INDEX__Parameter__ = 12;

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
