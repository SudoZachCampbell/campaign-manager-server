"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var react_bootstrap_1 = require("react-bootstrap");
var _ = require("lodash");
function Npc(props) {
    return (React.createElement("div", null,
        _.map(props.npc, function (p) {
            console.log(p);
            return (React.createElement("div", null, p));
        }),
        React.createElement(react_bootstrap_1.Button, { variant: "outline-info" }, "Details")));
}
exports.default = Npc;
//# sourceMappingURL=Npc.js.map