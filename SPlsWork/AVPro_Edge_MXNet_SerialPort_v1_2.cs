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

namespace UserModule_AVPRO_EDGE_MXNET_SERIALPORT_V1_2
{
    public class UserModuleClass_AVPRO_EDGE_MXNET_SERIALPORT_V1_2 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput RS232SEND;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> COMMANDSEND;
        Crestron.Logos.SplusObjects.StringInput MYCRESTRONCOMMSPEC;
        Crestron.Logos.SplusObjects.StringInput RS232TX;
        Crestron.Logos.SplusObjects.DigitalOutput ISINITIALIZED;
        Crestron.Logos.SplusObjects.StringOutput RS232RX;
        UShortParameter COMMANDPROCESSORID;
        UShortParameter DEVICETYPE;
        UShortParameter MATRIXINDEX;
        UShortParameter BAUD_RATE;
        UShortParameter DATA_BITS;
        UShortParameter STOP_BITS;
        UShortParameter DATA_PARITY;
        InOutArray<StringParameter> COMMANDSTRING;
        AVProEdgeMXNetLib.Components.SerialPortComponent SERIALPORT;
        ushort READY = 0;
        private void RESETOUTPUTS (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 116;
            ISINITIALIZED  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 120;
            RS232RX  .UpdateValue ( ""  ) ; 
            
            }
            
        public void ONINITIALIZE ( object __sender__ /*AVProEdgeMXNetLib.Components.SerialPortComponent SENDER */, AVProEdgeMXNetLib.EventArguments.DigEventArgs ARGS ) 
            { 
            SerialPortComponent  SENDER  = (SerialPortComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 127;
                ISINITIALIZED  .Value = (ushort) ( ARGS.Payload ) ; 
                __context__.SourceCodeLine = 128;
                READY = (ushort) ( ARGS.Payload ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void ONRX ( object __sender__ /*AVProEdgeMXNetLib.Components.SerialPortComponent SENDER */, AVProEdgeMXNetLib.EventArguments.SerEventArgs ARGS ) 
            { 
            SerialPortComponent  SENDER  = (SerialPortComponent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 133;
                RS232RX  .UpdateValue ( ARGS . Payload  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        object MYCRESTRONCOMMSPEC_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 144;
                SERIALPORT . SetCrestronCommSpec ( MYCRESTRONCOMMSPEC .ToString()) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object RS232SEND_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 151;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (READY == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 153;
                SERIALPORT . SendCommand ( RS232TX .ToString()) ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object COMMANDSEND_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort INDEX = 0;
        
        
        __context__.SourceCodeLine = 162;
        INDEX = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 164;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (READY == 1) ) && Functions.TestForTrue ( Functions.BoolToInt ( INDEX > 0 ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( INDEX <= 10 ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (COMMANDSTRING[ INDEX ] != "") )) ))  ) ) 
            {
            __context__.SourceCodeLine = 165;
            SERIALPORT . SendCommand ( COMMANDSTRING[ INDEX ] .ToString()) ; 
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
        
        __context__.SourceCodeLine = 174;
        READY = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 175;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 177;
        RESETOUTPUTS (  __context__  ) ; 
        __context__.SourceCodeLine = 179;
        // RegisterEvent( SERIALPORT , ONINITIALIZE , ONINITIALIZE ) 
        try { g_criticalSection.Enter(); SERIALPORT .OnInitialize  += ONINITIALIZE; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 180;
        // RegisterEvent( SERIALPORT , ONRX , ONRX ) 
        try { g_criticalSection.Enter(); SERIALPORT .OnRX  += ONRX; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 182;
        SERIALPORT . Configure ( (ushort)( COMMANDPROCESSORID  .Value ), (ushort)( DEVICETYPE  .Value ), (ushort)( MATRIXINDEX  .Value ), (ushort)( BAUD_RATE  .Value ), (ushort)( DATA_BITS  .Value ), (ushort)( STOP_BITS  .Value ), (ushort)( DATA_PARITY  .Value )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    RS232SEND = new Crestron.Logos.SplusObjects.DigitalInput( RS232SEND__DigitalInput__, this );
    m_DigitalInputList.Add( RS232SEND__DigitalInput__, RS232SEND );
    
    COMMANDSEND = new InOutArray<DigitalInput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        COMMANDSEND[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( COMMANDSEND__DigitalInput__ + i, COMMANDSEND__DigitalInput__, this );
        m_DigitalInputList.Add( COMMANDSEND__DigitalInput__ + i, COMMANDSEND[i+1] );
    }
    
    ISINITIALIZED = new Crestron.Logos.SplusObjects.DigitalOutput( ISINITIALIZED__DigitalOutput__, this );
    m_DigitalOutputList.Add( ISINITIALIZED__DigitalOutput__, ISINITIALIZED );
    
    MYCRESTRONCOMMSPEC = new Crestron.Logos.SplusObjects.StringInput( MYCRESTRONCOMMSPEC__AnalogSerialInput__, 100, this );
    m_StringInputList.Add( MYCRESTRONCOMMSPEC__AnalogSerialInput__, MYCRESTRONCOMMSPEC );
    
    RS232TX = new Crestron.Logos.SplusObjects.StringInput( RS232TX__AnalogSerialInput__, 65534, this );
    m_StringInputList.Add( RS232TX__AnalogSerialInput__, RS232TX );
    
    RS232RX = new Crestron.Logos.SplusObjects.StringOutput( RS232RX__AnalogSerialOutput__, this );
    m_StringOutputList.Add( RS232RX__AnalogSerialOutput__, RS232RX );
    
    COMMANDPROCESSORID = new UShortParameter( COMMANDPROCESSORID__Parameter__, this );
    m_ParameterList.Add( COMMANDPROCESSORID__Parameter__, COMMANDPROCESSORID );
    
    DEVICETYPE = new UShortParameter( DEVICETYPE__Parameter__, this );
    m_ParameterList.Add( DEVICETYPE__Parameter__, DEVICETYPE );
    
    MATRIXINDEX = new UShortParameter( MATRIXINDEX__Parameter__, this );
    m_ParameterList.Add( MATRIXINDEX__Parameter__, MATRIXINDEX );
    
    BAUD_RATE = new UShortParameter( BAUD_RATE__Parameter__, this );
    m_ParameterList.Add( BAUD_RATE__Parameter__, BAUD_RATE );
    
    DATA_BITS = new UShortParameter( DATA_BITS__Parameter__, this );
    m_ParameterList.Add( DATA_BITS__Parameter__, DATA_BITS );
    
    STOP_BITS = new UShortParameter( STOP_BITS__Parameter__, this );
    m_ParameterList.Add( STOP_BITS__Parameter__, STOP_BITS );
    
    DATA_PARITY = new UShortParameter( DATA_PARITY__Parameter__, this );
    m_ParameterList.Add( DATA_PARITY__Parameter__, DATA_PARITY );
    
    COMMANDSTRING = new InOutArray<StringParameter>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        COMMANDSTRING[i+1] = new StringParameter( COMMANDSTRING__Parameter__ + i, COMMANDSTRING__Parameter__, this );
        m_ParameterList.Add( COMMANDSTRING__Parameter__ + i, COMMANDSTRING[i+1] );
    }
    
    
    MYCRESTRONCOMMSPEC.OnSerialChange.Add( new InputChangeHandlerWrapper( MYCRESTRONCOMMSPEC_OnChange_0, true ) );
    RS232SEND.OnDigitalPush.Add( new InputChangeHandlerWrapper( RS232SEND_OnPush_1, true ) );
    for( uint i = 0; i < 10; i++ )
        COMMANDSEND[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( COMMANDSEND_OnPush_2, true ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    SERIALPORT  = new AVProEdgeMXNetLib.Components.SerialPortComponent();
    
    
}

public UserModuleClass_AVPRO_EDGE_MXNET_SERIALPORT_V1_2 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint RS232SEND__DigitalInput__ = 0;
const uint COMMANDSEND__DigitalInput__ = 1;
const uint MYCRESTRONCOMMSPEC__AnalogSerialInput__ = 0;
const uint RS232TX__AnalogSerialInput__ = 1;
const uint ISINITIALIZED__DigitalOutput__ = 0;
const uint RS232RX__AnalogSerialOutput__ = 0;
const uint COMMANDPROCESSORID__Parameter__ = 10;
const uint DEVICETYPE__Parameter__ = 11;
const uint MATRIXINDEX__Parameter__ = 12;
const uint BAUD_RATE__Parameter__ = 13;
const uint DATA_BITS__Parameter__ = 14;
const uint STOP_BITS__Parameter__ = 15;
const uint DATA_PARITY__Parameter__ = 16;
const uint COMMANDSTRING__Parameter__ = 17;

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
