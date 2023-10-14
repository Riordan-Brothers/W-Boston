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

namespace UserModule_CONTROLWORKS_TVPRESET_WITH_LABEL_V1_0
{
    public class UserModuleClass_CONTROLWORKS_TVPRESET_WITH_LABEL_V1_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput REFRESHOUTPUTS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> PRESETLABELSTORE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> PRESETLABELRESET;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> PRESETCHANNELNUMBERIN;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> PRESETLABELIN__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> PRESETENABLEDFB;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> PRESETCHANNELNUMBEROUT;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> PRESETLABELOUT__DOLLAR__;
        object PRESETLABELSTORE_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort I = 0;
                
                
                __context__.SourceCodeLine = 56;
                I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 57;
                _SplusNVRAM.PRESETLABEL [ I ]  .UpdateValue ( PRESETLABELIN__DOLLAR__ [ I ]  ) ; 
                __context__.SourceCodeLine = 58;
                PRESETLABELOUT__DOLLAR__ [ I]  .UpdateValue ( _SplusNVRAM.PRESETLABEL [ I ]  ) ; 
                __context__.SourceCodeLine = 59;
                PRESETENABLEDFB [ I]  .Value = (ushort) ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( _SplusNVRAM.PRESETLABEL[ I ] ) > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( _SplusNVRAM.PRESETCHANNELNUMBER[ I ] > 0 ) )) ) ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object PRESETLABELRESET_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 64;
            I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
            __context__.SourceCodeLine = 65;
            PRESETLABELOUT__DOLLAR__ [ I]  .UpdateValue ( _SplusNVRAM.PRESETLABEL [ I ]  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object PRESETCHANNELNUMBERIN_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 69;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 70;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PRESETCHANNELNUMBERIN[ I ] .UshortValue != _SplusNVRAM.PRESETCHANNELNUMBER[ I ]))  ) ) 
            { 
            __context__.SourceCodeLine = 71;
            _SplusNVRAM.PRESETCHANNELNUMBER [ I] = (ushort) ( PRESETCHANNELNUMBERIN[ I ] .UshortValue ) ; 
            __context__.SourceCodeLine = 72;
            PRESETCHANNELNUMBEROUT [ I]  .Value = (ushort) ( _SplusNVRAM.PRESETCHANNELNUMBER[ I ] ) ; 
            __context__.SourceCodeLine = 73;
            PRESETENABLEDFB [ I]  .Value = (ushort) ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( _SplusNVRAM.PRESETLABEL[ I ] ) > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( _SplusNVRAM.PRESETCHANNELNUMBER[ I ] > 0 ) )) ) ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    ushort I = 0;
    
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 86;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 87;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)10; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 88;
            PRESETLABELOUT__DOLLAR__ [ I]  .UpdateValue ( _SplusNVRAM.PRESETLABEL [ I ]  ) ; 
            __context__.SourceCodeLine = 89;
            PRESETCHANNELNUMBEROUT [ I]  .Value = (ushort) ( _SplusNVRAM.PRESETCHANNELNUMBER[ I ] ) ; 
            __context__.SourceCodeLine = 90;
            PRESETENABLEDFB [ I]  .Value = (ushort) ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( _SplusNVRAM.PRESETLABEL[ I ] ) > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( _SplusNVRAM.PRESETCHANNELNUMBER[ I ] > 0 ) )) ) ) ; 
            __context__.SourceCodeLine = 87;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    SocketInfo __socketinfo__ = new SocketInfo( 1, this );
    InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
    _SplusNVRAM = new SplusNVRAM( this );
    _SplusNVRAM.PRESETCHANNELNUMBER  = new ushort[ 11 ];
    _SplusNVRAM.PRESETLABEL  = new CrestronString[ 11 ];
    for( uint i = 0; i < 11; i++ )
        _SplusNVRAM.PRESETLABEL [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    
    REFRESHOUTPUTS = new Crestron.Logos.SplusObjects.DigitalInput( REFRESHOUTPUTS__DigitalInput__, this );
    m_DigitalInputList.Add( REFRESHOUTPUTS__DigitalInput__, REFRESHOUTPUTS );
    
    PRESETLABELSTORE = new InOutArray<DigitalInput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        PRESETLABELSTORE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( PRESETLABELSTORE__DigitalInput__ + i, PRESETLABELSTORE__DigitalInput__, this );
        m_DigitalInputList.Add( PRESETLABELSTORE__DigitalInput__ + i, PRESETLABELSTORE[i+1] );
    }
    
    PRESETLABELRESET = new InOutArray<DigitalInput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        PRESETLABELRESET[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( PRESETLABELRESET__DigitalInput__ + i, PRESETLABELRESET__DigitalInput__, this );
        m_DigitalInputList.Add( PRESETLABELRESET__DigitalInput__ + i, PRESETLABELRESET[i+1] );
    }
    
    PRESETENABLEDFB = new InOutArray<DigitalOutput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        PRESETENABLEDFB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( PRESETENABLEDFB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( PRESETENABLEDFB__DigitalOutput__ + i, PRESETENABLEDFB[i+1] );
    }
    
    PRESETCHANNELNUMBERIN = new InOutArray<AnalogInput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        PRESETCHANNELNUMBERIN[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( PRESETCHANNELNUMBERIN__AnalogSerialInput__ + i, PRESETCHANNELNUMBERIN__AnalogSerialInput__, this );
        m_AnalogInputList.Add( PRESETCHANNELNUMBERIN__AnalogSerialInput__ + i, PRESETCHANNELNUMBERIN[i+1] );
    }
    
    PRESETCHANNELNUMBEROUT = new InOutArray<AnalogOutput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        PRESETCHANNELNUMBEROUT[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( PRESETCHANNELNUMBEROUT__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( PRESETCHANNELNUMBEROUT__AnalogSerialOutput__ + i, PRESETCHANNELNUMBEROUT[i+1] );
    }
    
    PRESETLABELIN__DOLLAR__ = new InOutArray<StringInput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        PRESETLABELIN__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringInput( PRESETLABELIN__DOLLAR____AnalogSerialInput__ + i, PRESETLABELIN__DOLLAR____AnalogSerialInput__, 50, this );
        m_StringInputList.Add( PRESETLABELIN__DOLLAR____AnalogSerialInput__ + i, PRESETLABELIN__DOLLAR__[i+1] );
    }
    
    PRESETLABELOUT__DOLLAR__ = new InOutArray<StringOutput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        PRESETLABELOUT__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( PRESETLABELOUT__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( PRESETLABELOUT__DOLLAR____AnalogSerialOutput__ + i, PRESETLABELOUT__DOLLAR__[i+1] );
    }
    
    
    for( uint i = 0; i < 10; i++ )
        PRESETLABELSTORE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( PRESETLABELSTORE_OnPush_0, false ) );
        
    for( uint i = 0; i < 10; i++ )
        PRESETLABELRESET[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( PRESETLABELRESET_OnPush_1, false ) );
        
    for( uint i = 0; i < 10; i++ )
        PRESETCHANNELNUMBERIN[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( PRESETCHANNELNUMBERIN_OnChange_2, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_CONTROLWORKS_TVPRESET_WITH_LABEL_V1_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint REFRESHOUTPUTS__DigitalInput__ = 0;
const uint PRESETLABELSTORE__DigitalInput__ = 1;
const uint PRESETLABELRESET__DigitalInput__ = 11;
const uint PRESETCHANNELNUMBERIN__AnalogSerialInput__ = 0;
const uint PRESETLABELIN__DOLLAR____AnalogSerialInput__ = 10;
const uint PRESETENABLEDFB__DigitalOutput__ = 0;
const uint PRESETCHANNELNUMBEROUT__AnalogSerialOutput__ = 0;
const uint PRESETLABELOUT__DOLLAR____AnalogSerialOutput__ = 10;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public ushort [] PRESETCHANNELNUMBER;
            [SplusStructAttribute(1, false, true)]
            public CrestronString [] PRESETLABEL;
            
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
