import React from "react";
import { BrowserRouter, Route, Switch } from "react-router-dom";
import Dashboard from "../components/features/admin/Dashboard";
import Login from "../components/features/Login";
import NotFound from "../components/features/NotFound";
import Root from "../components/Root";
import { ProtectedRoute } from "./protected.route";

const Router = () => {
  return (
    <BrowserRouter>
      <Switch>
        <Route exact path="/" component={Root} />
        <Route exact path="/admin" component={Login} />
        <ProtectedRoute exact path="/admin/dashboard" component={Dashboard} />
        <Route path="*" component={NotFound} />
      </Switch>
    </BrowserRouter>
  );
};

export default Router;
