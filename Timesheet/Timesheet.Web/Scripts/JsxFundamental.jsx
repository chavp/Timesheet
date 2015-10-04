class HelloWorld extends React.Component {
    render() {
        return (<div> Hello {this.props.name} {this.props.message} </div>);
    }
};

var FormComponent = React.createClass({
    render: function() {
        return <form>{this.props.children}</form>;
    }
});

FormComponent.Row = React.createClass({
    render: function() {
        return <fieldset>{this.props.children}</fieldset>;
    }
});

FormComponent.Label = React.createClass({
    render: function() {
        return <label htmlFor={this.props.for}>{this.props.text}{this.props.children}</label>;
    }
});

FormComponent.Input = React.createClass({
    render: function() {
        return <input type={this.props.type} id={this.props.id} htmlCls="form-control" />;
    }
});
var Form = FormComponent;

var input1 = {
    "type": "text",
    "text": "label",
    "id": "txt"
};
var input2 = {
    "type": "checkbox",
    "text": "label",
    "id": "chx"
};

var App = (
            <Form>
                <Form.Row>
                    <Form.Label {...input1}>
                        <Form.Input {...input1} />
                    </Form.Label>
                </Form.Row>
                <Form.Row>
                    <Form.Label {...input2}>
                        <Form.Input {...input2} />
                    </Form.Label>
                </Form.Row>
            </Form>
);

var greeting = {
                        name: "Dhing",
                        message: "5555"
                    }

class ListItem extends React.Component {
    render() {
        return <li>{this.props.text}</li>;
    }
}
class BigList extends React.Component {
    render() {
        var items = [ "item1", "item2", "item3", "item4" ];
        var formattedItems = [];
        for (var i = 0, ii = items.length; i < ii; i++ ) {
            var textObj = { text: items[i] };
            formattedItems.push(<ListItem {...textObj} />);
        }
        return <ul>{formattedItems}</ul>;
    }
}

var SignIn = React.createClass({
    render: function() {
        return <a href="/signin">Sign In</a>;
    }
});

var UserMenu = React.createClass({
    render: function() {
        return <ul className="usermenu"><li>Item</li><li>
        Another</li></ul>;
    }
});

var userIsSignedIn = true;
var MainApp = React.createClass({
    render: function() {
        var navElement = userIsSignedIn ? <UserMenu /> : <SignIn />;
        return <div>{navElement}</div>;
    }
});

var Counter = React.createClass({
    incrementCount: function(){
        this.setState({
            count: this.state.count + 1
        });
    },
    getInitialState: function(){
        return {
            count: 0
        }
    },
    render: function(){
        return (
          <div className="counter">
            <h1>Count: {this.state.count}</h1>
            <button type="button" onClick={this.incrementCount}>Increment</button>
          </div>
      );
    }
});

var FilteredList = React.createClass({
    filterList: function(event){
        var updatedList = this.state.initialItems;
        updatedList = updatedList.filter(function(item){
            return item.toLowerCase().search(
              event.target.value.toLowerCase()) !== -1;
        });
        this.setState({items: updatedList});
    },
    getInitialState: function(){
        return {
            initialItems: [
              "Apples",
              "Broccoli",
              "Chicken",
              "Duck",
              "Eggs",
              "Fish",
              "Granola",
              "Hash Browns"
            ],
            items: []
        }
    },
    componentWillMount: function(){
        this.setState({items: this.state.initialItems})
    },
    render: function(){
        return (
          <div className="filter-list">
            <input type="text" placeholder="Search" onChange={this.filterList}/>
          <List items={this.state.items}/>
          </div>
      );
    }
});

var List = React.createClass({
    render: function(){
        return (
          <ul>
          {
              this.props.items.map(function(item) {
                  return <li key={item}>{item}</li>
              })
          }
          </ul>
        )  
    }
});

React.render(
    <FilteredList />,
    document.getElementById('helloWorld')
);