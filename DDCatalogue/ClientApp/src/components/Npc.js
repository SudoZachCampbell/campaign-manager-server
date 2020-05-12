"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var react_bootstrap_1 = require("react-bootstrap");
function Npc(props) {
    return (React.createElement("div", null,
        React.createElement("div", null,
            React.createElement("div", null, props.npc.Name),
            React.createElement("div", null, props.npc.Monster ? props.npc.Monster.Name : "None")),
        React.createElement(react_bootstrap_1.Button, { variant: "outline-info" }, "Details")));
}
exports.default = Npc;
//# sourceMappingURL=Npc.js.map