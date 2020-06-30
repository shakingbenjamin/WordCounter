import React from "react";

export default class FetchWordList extends React.Component {
    state = {
        loading: true,
        words: null
    }

    async componentDidMount() {
        const url = "https://localhost:5001/wordcounter";
        const response = await fetch(url);
        const data = await response.json();
        console.log(data);
        this.setState({words: data});
        this.setState({loading: false})
    }

    render() {
    return (
        <div>{
            this.state.loading ? <div>Loading...</div> : 
        <ul>{this.state.words.map(item => {
        return <ul><strong>{item.word}</strong> was mentioned {item.total} times</ul>
        })}</ul>}
        </div>);
    }
}