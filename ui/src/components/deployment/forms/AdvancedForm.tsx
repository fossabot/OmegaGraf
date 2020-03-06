import React, { useReducer, useEffect } from 'react';
import { SettingsReducer, ActionTypes } from '../reducers/SettingsReducer';
import AddSystem from '../inputs/AddSystem';
import { UseGlobalSettings } from '../../Global';
import TextField from '../inputs/TextField';
import FormView from '../../../views/Form';

export default function AdvancedForm() {
  const [globalSettings] = UseGlobalSettings();
  const [state, dispatch] = useReducer(SettingsReducer, globalSettings);

  useEffect(() => {
    dispatch({
      type: ActionTypes.Reset,
      value: globalSettings
    });
  }, [globalSettings]);

  console.log(state.Grafana.BuildInput);
  console.log(state.Grafana.BuildInput.Ports[3000]);

  const port = state.Grafana.BuildInput.Ports[3000];

  return (
    <FormView
      state={state}
      page="advanced"
      pageName="Advanced"
      title="Deploying Level 3"
      description="Please enter your preferences."
    >
      <AddSystem dispatch={dispatch} state={state} />

      <br />

      <TextField
        dispatch={dispatch}
        label="Prometheus Global Scrape Interval"
        type={ActionTypes.PrometheusConfigDataScrapeIntervalShort}
        value={state.Prometheus.Config[0].Data.Global.ScrapeInterval}
      />

      <TextField
        dispatch={dispatch}
        label="Prometheus vCenter Scrape Interval"
        type={ActionTypes.PrometheusConfigDataScrapeIntervalLong}
        value={state.Prometheus.Config[0].Data.ScrapeConfigs[1]?.ScrapeInterval}
      />

      <TextField
        dispatch={dispatch}
        label="Grafana Port Number"
        type={ActionTypes.GrafanaBuildConfigurationPort}
        value={port ? port.valueOf().toString() : '0'}
      />
    </FormView>
  );
}
