import React from 'react';
import Router, { Route, DefaultRoute, NotFoundRoute, HistoryLocation, HashLocation } from 'react-router';
import RouterContainer from './utils/RouterContainer';
import App from './components/App';
import Login from './components/Login/Login';
import Dashboard from './components/dashboard/Dashboard';

let Routes = (
    <Route path='/' handler={App}>
		<DefaultRoute name="dashboard" handler={Dashboard} />
		<Route name="login" handler={Login}/>
		</Route>
	</Route>
);

let location = HashLocation;
var router = Router.create({ routes: Routes, location });
RouterContainer.set(router);
export default router;