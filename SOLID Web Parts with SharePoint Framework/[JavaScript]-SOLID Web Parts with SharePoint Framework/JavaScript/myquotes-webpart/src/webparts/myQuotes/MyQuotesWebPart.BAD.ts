import {
    Environment,
    EnvironmentType,
    Version
} from '@microsoft/sp-core-library';
import {
  BaseClientSideWebPart,
  IPropertyPaneConfiguration,
  PropertyPaneTextField
} from '@microsoft/sp-webpart-base';
import { escape } from '@microsoft/sp-lodash-subset';

import styles from './MyQuotesWebPart.module.scss';
import * as strings from 'MyQuotesWebPartStrings';
import MockData from './MockData';

import {
  SPHttpClient,
  SPHttpClientResponse   
 } from '@microsoft/sp-http';

export interface IMyQuotesWebPartProps {
  description: string;
}

export interface IQuotes {
  Quotes: IQuote[];
}

export interface IQuote {
  Author: string;
  Quote: string;
}

export default class MyQuotesWebPart extends BaseClientSideWebPart<IMyQuotesWebPartProps> {

  public render(): void {
    this.domElement.innerHTML = `
      <div class="${styles.myQuotes}">
        <div class="${styles.container}">
          <div class="ms-Grid-row ms-bgColor-themeDark ms-fontColor-white ${styles.row}">
            <div class="ms-Grid-col ms-lg10 ms-xl8 ms-xlPush2 ms-lgPush1">
              <span class="ms-font-xl ms-fontColor-white">Famous Quotes</span>
              <div class="ms-font-l ms-fontColor-white" id="quotesContainer"></div>
            </div>
          </div>
        </div>
      </div>`;

      this.renderData();
  }

  protected get dataVersion(): Version {
    return Version.parse('1.0');
  }

  protected getPropertyPaneConfiguration(): IPropertyPaneConfiguration {
    return {
      pages: [
        {
          header: {
            description: strings.PropertyPaneDescription
          },
          groups: [
            {
              groupName: strings.BasicGroupName,
              groupFields: [
                PropertyPaneTextField('description', {
                  label: strings.DescriptionFieldLabel
                })
              ]
            }
          ]
        }
      ]
    };
  }

  private getMockData(): Promise<IQuotes> {
    return MockData.get()
      .then((data: IQuote[]) => {
        var listData: IQuotes = { Quotes: data };
        return listData;
      }) as Promise<IQuotes>;
  }

  private getRealData(): Promise<IQuotes> {
    return this.context.spHttpClient.get(this.context.pageContext.web.absoluteUrl + `/_api/web/lists`, SPHttpClient.configurations.v1)
      .then((response: SPHttpClientResponse) => {
        return response.json();
    });
  }

  private renderData(): void {
    if (Environment.type === EnvironmentType.SharePoint || Environment.type === EnvironmentType.ClassicSharePoint) {
      this.getRealData().then((response) => {
        this.renderQuotes(response.Quotes);
      });
    }
    else if (Environment.type === EnvironmentType.Local) {
      this.getMockData().then((response) => {
        this.renderQuotes(response.Quotes);
      });
    }
  }

  private renderQuotes(items: IQuote[]): void {
    let html: string = '';
    items.forEach((item: IQuote) => {
      html += `
        <div>${escape(item.Quote)}</div>
        <div class="${styles.author}">${escape(item.Author)}</div>  
      `;
    });
 
    const listContainer: Element = this.domElement.querySelector('#quotesContainer');
    listContainer.innerHTML = html;
  }
}
