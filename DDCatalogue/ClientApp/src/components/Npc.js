"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var react_bootstrap_1 = require("react-bootstrap");
function Npc(props) {
    return (React.createElement("div", null,
        props.npc.map(function (p) {
            return (React.createElement("div", null, p));
        }),
        React.createElement(react_bootstrap_1.Button, { variant: "outline-info" }, "Details")));
}
exports.default = Npc;
//# sourceMappingURL=Npc.js.map