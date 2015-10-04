var HelloText = React.createClass({
    render: function(){
        return (
            <div className="helloText">Hello World!</div>
        );
    }
});

class SaveBtn extends React.Component{
    render(){
        return React.createElement(
            "a",
            { "class": "btn" },
            "Save"
        );
    }
};

class Display extends React.Component {
    render() {
        return (
            <div>
                {this.props.name}
            </div>
        );
    }
};

var MyComponent = React.createClass({
    render: function() {
        React.Children.map(this.props.children, function(child){
            console.log(child)
        });
        return (
        <div>
            {this.props.name}
        </div>
        );
    }
});

var IntroReact = React.createClass({
    getInitialState: function() {
        console.log(this.props.initialData);
        return { data: this.props.initialData };
    },
    render: function(){
        return (
            <div>
                <HelloText />
                <Display name="Test" />
                <SaveBtn />
            </div>
        );
    }
});

//React.render(
//    <MyComponent name="frodo" >
//        <p key="firsty">a child</p>
//        <p key="2">another</p>
//    </MyComponent>, 
//    document.getElementById('container')
//);