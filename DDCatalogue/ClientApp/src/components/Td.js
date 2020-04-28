"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var react_router_dom_1 = require("react-router-dom");
function Td(props) {
    // Conditionally wrapping content into a link
    var ContentTag = props.to ? react_router_dom_1.Link : 'div';
    return (React.createElement("td", null,
        React.createElement(ContentTag, { to: props.to }, props.children)));
}
exports.default = Td;
//# sourceMappingURL=Td.js.map