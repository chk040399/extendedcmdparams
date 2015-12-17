# extendedcmdparams
sample project to fix some issues for a helper class ExtendedCmdParams (MVVM)

# projest summary
this is a sample project to implement a helper class to use in MVVM Pattern

the class is called ExtendeCommandParams and its purpose is to act use in XAML to indicate advanced params
Examples

<Button Command="{Binding ConvertTextCommand}" Margin="5" IsDefault="True">Convert
<Button.CommandParameter>
            <ViewModel:ExtendedCommandParam>
                <system:String x:Key="param1">param1Value</system:String>
                <system:String x:Key="param2">param2Value</system:String>
                <StaticResource x:Key="param3" ResourceKey="resString"/>
                <ViewModel:ObjectProxy x:Key="param4" RefObject="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType=UserControl}}"/>
                <ViewModel:ObjectProxy x:Key="param5" >
                    <ViewModel:ObjectProxy.RefObject>
                        <system:String >param5Value</system:String>
                    </ViewModel:ObjectProxy.RefObject>
                </ViewModel:ObjectProxy>

                <ViewModel:ObjectProxy x:Key="param6" >
                    <ViewModel:ObjectProxy.RefObject>
                        <StaticResource ResourceKey="resString"/>
                    </ViewModel:ObjectProxy.RefObject>
                </ViewModel:ObjectProxy>

                <ViewModel:ObjectProxy x:Key="param7" >
                    <ViewModel:ObjectProxy.RefObject>
                        <Binding Path="SomeText"/>
                    </ViewModel:ObjectProxy.RefObject>
                </ViewModel:ObjectProxy>
            </ViewModel:ExtendedCommandParam>

        </Button.CommandParameter>
    </Button>
    
ExtendedCommandParam can pass to the commnd handler multiple objects indicated by XAML, for this reason ExtendedCommandParam implements IDictionary in order to be used in XAML as an element which can hold child elements

One issue with this is the fact that the childs are new instances of objects, We cant add an existing object to the parameters Collection, so I created a class (ObjectProxy) which has the mission to act as a proxy to existing objects. The Add Method of IDictionary is taking into account the objet type before adding it, and if the object type is ObjectProxy, it'll not add the object itself but an object referenced by it (RefObject Property)

   class ObjectProxy :DependencyObject
    {
        public object RefObject
        {
            get { return GetValue(RefObjectProperty); }
            set { SetValue(RefObjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RefObject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RefObjectProperty =
            DependencyProperty.Register("RefObject", typeof(object), typeof(ObjectProxy), new PropertyMetadata(null));


    }


# the issue
RefObject Property is implemented as a Dependency Prop in order to use databinding, but the current implementation has an issue it always return a null value !!! :(

An example is provided to reproduce the issue, When the command is invoked the parameters list is displayed

What's Wrong with my implementation


What's Wrong with this impelmentation